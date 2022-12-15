using Database_Service.Model;

/// <summary>
/// Data transfer object for representing a shopping cart in the application
/// </summary>
namespace Database_Service.DTO
{
    public class CartReadDTO
    {
        /// <summary>
        /// List of order lines in the cart
        /// </summary>
        public List<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Indicates whether the user is logged in
        /// </summary>
        public bool Loggedin { get; set; }

        /// <summary>
        /// Calculate the subtotal of the order lines in the cart
        /// </summary>
        public double CalcSubTotal()
        {
            double sum = 0;

            foreach (OrderLine line in OrderLines)
            {
                sum += line.CalcSubTotal();
            }

            return sum;
        }
    }
}
