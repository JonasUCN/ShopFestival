using DesktopApp.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLayer;

namespace DesktopApp
{
    public partial class OrdreView : Form
    {
        SaleOrderController SaleOrderController;
        Form LastPage;
        public OrdreView(Form lastPage)
        {
            InitializeComponent();
            LastPage = lastPage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LastPage.Show();
            this.Close();
        }

        private void OrdreView_Load(object sender, EventArgs e)
        {
            LastPage.Hide();
            getAllSaleOrders();
        }

        private async void getAllSaleOrders()
        {
            SaleOrderController = new SaleOrderController();
            List<SaleOrder> saleOrders = await SaleOrderController.GetSaleOrder();
            var bindingList = new BindingList<SaleOrder>(saleOrders);
            var source = new BindingSource(bindingList, null);
            dgv_SaleOrders.DataSource = source;
        }

        private void OrdreView_FormClosed(object sender, FormClosedEventArgs e)
        {

            LastPage.Show();
        }

        private void btn_activeOrders_Click(object sender, EventArgs e)
        {
            SaleOrderController = new SaleOrderController();
            List<SaleOrder> saleOrders = SaleOrderController.GetActiveSaleOrderes();
            var bindingList = new BindingList<SaleOrder>(saleOrders);
            var source = new BindingSource(bindingList, null);
            dgv_SaleOrders.DataSource = source;
        }
    }
}
