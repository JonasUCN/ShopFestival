using DesktopApp.DataAccess;


namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ProductAccess product = new ProductAccess();
            product.GetProductByID(3);
        }

        private void btn_createProduct_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}