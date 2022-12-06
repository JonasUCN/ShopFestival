namespace WebShop.Models
{
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal
        {
            get
            {
                return Product.Price * Quantity;
            }
        }
    }
}
