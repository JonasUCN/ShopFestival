using ModelLayer;
using DesktopApp.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class StockOverview : Form
    {
        ProductController _ProductController;
        Form LastPage;
        public StockOverview(Form LastPage)
        {
            InitializeComponent();
            this.LastPage = LastPage;





        }

        private async Task GetAllProductsAsync()
        {
            _ProductController = new ProductController();
            List<Product> inventory = await _ProductController.GetProductsAsync();
            var bindingList = new BindingList<Product>(inventory);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private async void StockOverview_Load(object sender, EventArgs e)
        {
            LastPage.Hide();
            await GetAllProductsAsync();
        }

        private void StockOverview_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastPage.Show();

        }
    }
}
