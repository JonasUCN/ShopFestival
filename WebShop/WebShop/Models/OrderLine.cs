namespace WebShop.Models
{
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public double CalcSubTotal()
        {
            double sum = 0;

            sum = (double)Product.Price * Quantity;

            return sum;
        }
    }
}
