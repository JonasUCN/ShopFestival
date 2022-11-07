using DesktopApp.Controller;
using DesktopApp.DataAccess;


namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_createProduct_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_createTitle.Text) &&
                !String.IsNullOrEmpty(txt_createBrand.Text) &&
                !String.IsNullOrEmpty(txt_createProductDescription.Text)&&
                Int32.TryParse(txt_createStock.Text, out int Stock)&&
                Decimal.TryParse(txt_createPrice.Text, out decimal Price))
            {

                ProductController productController = new ProductController();
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

            



           

            //Hello
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}