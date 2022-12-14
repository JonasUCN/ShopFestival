namespace Database_Service.Model
{
    public class SaleOrder
    {
        public int OrderNo { get; set; }
        public string Status { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer customer { get; set; }
        public List<OrderLine> orderLines { get; set; }
        public OrderAddress OrderAddress { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleOrder"/> class.
        /// </summary>
        public SaleOrder()
        {
            orderLines = new List<OrderLine>();
            OrderDate = DateTime.Now;
            Status = "Active";
            customer = new();
        }
    }
}
