﻿using DesktopApp.ModelLayer;
using DesktopApp.LogicController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using DesktopApp.ServiceLayer;

namespace DesktopApp
{
    public partial class StockOverview : Form
    {
        ProductController _ProductController;
        Form LastPage;
        IConfiguration configuration;
        public StockOverview(Form LastPage)
        {
            InitializeComponent();
            this.LastPage = LastPage;
            _ProductController = new ProductController(new ProductAccess(configuration));
        }

        private  void GetAllProducts()
        {


            List<Product> inventory = _ProductController.GetProducts();
            var bindingList = new BindingList<Product>(inventory);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private async void StockOverview_Load(object sender, EventArgs e)
        {
            LastPage.Hide();
             GetAllProducts();
        }

        private void StockOverview_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastPage.Show();

        }
    }
}
