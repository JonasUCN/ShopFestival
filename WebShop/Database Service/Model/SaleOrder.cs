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
        public SaleOrder()
        {
            OrderDate = DateTime.Now;
            Status = "Active";
            customer = new();
        }
    }
}
