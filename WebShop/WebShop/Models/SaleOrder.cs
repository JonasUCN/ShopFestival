namespace WebShop.Models
{
    /// <summary>
    /// Represents a sale order, containing information about the order such as the order number, status, and order date, as well as a list of order lines and customer and delivery information.
    /// </summary>
    public class SaleOrder
    {
        public int OrderNo { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderLine> orderLines { get; set; } //Set; is for testing 
        public Customer customer { get; set; } //Set; is for testing in the view & controller
        public OrderAddress OrderAddress { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleOrder"/> class.
        /// </summary>
        public SaleOrder()
        {
            customer = new Customer();
        }

        /// <summary>
        /// Calculates the total price of all items in the order.
        /// </summary>
        /// <returns>The total price of the order.</returns>
        public double GetTotalPrice()
        {
            double sum = 0;
            foreach (var item in orderLines)
            {
                sum += item.CalcSubTotal();
            }
            return sum;
        }
    }
}
