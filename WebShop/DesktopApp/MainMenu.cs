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
    public partial class MainMenu : Form
    {
        OrdreView _orderView = null;
        StockOverview _StockOverview = null;
        Form1 _Form1 = null;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn_StockOverview_Click(object sender, EventArgs e)
        {
            _StockOverview  = new StockOverview(this);
            _StockOverview.Show();
        }

        private void btn_CreateProduct_Click(object sender, EventArgs e)
        {
            _Form1 = new Form1(this);
            _Form1.Show();
        }

        private void btn_OrderOverview_Click(object sender, EventArgs e)
        {
            _orderView = new OrdreView(this);
            _orderView.Show();

        }
    }
}
