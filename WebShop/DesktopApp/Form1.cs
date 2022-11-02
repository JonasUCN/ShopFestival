using DesktopApp.Controller;
using DesktopApp.DataAccess;


namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //ProductAccess product = new ProductAccess();
            //product.GetProductByID(3);
        }

        private void btn_createProduct_Click(object sender, EventArgs e)
        {
            ProductController productController = new ProductController();
            productController.createProduct(22, 4, "dfhjdf", "sdsd", "dgfdf");

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