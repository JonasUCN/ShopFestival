using DesktopApp.LogicControllers;
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
using DesktopApp.ModelLayer;
using DesktopApp.ServiceLayer;
using Microsoft.Extensions.Configuration;

namespace DesktopApp
{
    public partial class OrdreView : Form
    {
        SaleOrderController SaleOrderController;
        Form LastPage;
        IConfiguration configuration;
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

        private void getAllSaleOrders()
        {
            SaleOrderController = new SaleOrderController(new SaleOrderAccess(configuration));
            List<SaleOrder> saleOrders =  SaleOrderController.GetAllSaleOrders();
            var bindingList = new BindingList<SaleOrder>(saleOrders);
            var source = new BindingSource(bindingList, null);
            dgv_SaleOrders.DataSource = source;
        }

        private void OrdreView_FormClosed(object sender, FormClosedEventArgs e)
        {

            LastPage.Show();
        }

        private  void btn_activeOrders_ClickAsync(object sender, EventArgs e)
        {
            SaleOrderController = new SaleOrderController(new SaleOrderAccess(configuration));
            List<SaleOrder> saleOrders = SaleOrderController.GetActiveSaleOrderes();
            var bindingList = new BindingList<SaleOrder>(saleOrders);
            var source = new BindingSource(bindingList, null);
            dgv_SaleOrders.DataSource = source;
        }
    }
}
