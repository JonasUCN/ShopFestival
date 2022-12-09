using DesktopApp.LogicController;
using DesktopApp.ServiceLayer;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Security.Cryptography;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        Form LastPage;
        IConfiguration configuration;
        public Form1(Form lastPage)
        {
            InitializeComponent();
            LastPage = lastPage;
            
        }

        private void btn_createProduct_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_createTitle.Text) &&
                !String.IsNullOrEmpty(txt_createBrand.Text) &&
                !String.IsNullOrEmpty(txt_createProductDescription.Text)&&
                Int32.TryParse(txt_createStock.Text, out int Stock)&&
                Decimal.TryParse(txt_createPrice.Text, out decimal Price))
            {

                ProductController productController = new ProductController(new ProductAccess(configuration));
               bool success = productController.createProduct(Price, Stock, txt_createProductDescription.Text, txt_createBrand.Text, txt_createTitle.Text);

                if (success)
                {
                    lbl_createProductSuccess.Text = "Produktet blev oprettet";
                }
                else
                {
                    lbl_createProductSuccess.Text = "Produktet blev ikke oprettet";
                }

            }
            else
            {
                lbl_createProductSuccess.Text = "Fejl i indtastning";
            }

            



           

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LastPage.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastPage.Show();
        }
    }
}