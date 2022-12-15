namespace Database_Service.Model
{
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Calculates the subtotal for a purchase by multiplying the product price by the quantity.
        /// </summary>
        /// <returns>The subtotal for the purchase.</returns>
        public double CalcSubTotal()
        {
            double sum = 0;
            sum = (double)Product.Price * Quantity;
            return sum;
        }
    }
}
