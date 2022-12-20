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
            orderLines = new List<OrderLine>();
            OrderDate = DateTime.Now;
            Status = "Active";
            customer = new Customer();
        }
    }
}
