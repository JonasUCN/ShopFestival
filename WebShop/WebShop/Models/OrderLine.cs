namespace WebShop.Models
{
    /// <summary>
    /// Represents a line item in an order, containing a product and a quantity.
    /// </summary>
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Calculates the subtotal for this order line by multiplying the product price by the quantity.
        /// </summary>
        /// <returns>The subtotal for this order line.</returns>
        public double CalcSubTotal()
        {
            double sum = 0;

            sum = (double)Product.Price * Quantity;

            return sum;
        }
    }
}
