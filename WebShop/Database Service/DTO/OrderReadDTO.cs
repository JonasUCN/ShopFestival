using Database_Service.Model;

namespace Database_Service.DTO
{
    /// <summary>
    /// A data transfer object (DTO) for storing information about an order.
    /// </summary>
    public class OrderReadDTO
    {
        public int OrderNo { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderLine> orderLines { get; set; } //Set; is for testing 
        public Customer customer { get; set; } //Set; is for testing in the view & controller

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReadDTO"/> class.
        /// </summary>
        public OrderReadDTO()
        {
            // initialize the customer property
            customer = new Customer();
        }
        /// <summary>
        /// Calculates the total price of the order.
        /// </summary>
        /// <returns>The total price of the order.</returns>
        public double GetTotalPrice()
        {
            // initialize the sum to 0
            double sum = 0;
            // loop through each order line and add the subtotal to the sum
            foreach (var item in orderLines)
            {
                sum += item.CalcSubTotal();
            }
            // return the sum
            return sum;
        }
    }
}
