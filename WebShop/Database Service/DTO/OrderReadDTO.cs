using Database_Service.Model;

namespace Database_Service.DTO
{
    public class OrderReadDTO
    {
        //TODO: Skal måske indholde mere fra SaleOrder.cs fra Model
        public List<OrderLine> orderLines { get; set; } //Set; is for testing 
        public Customer customer { get; set; } //Set; is for testing in the view & controller

        public OrderReadDTO()
        {
            customer = new Customer();
        }
        public double GetTotalPrice()
        {
            double sum = 0;
            foreach (var item in orderLines)
            {
                sum += (double)item.SubTotal;
            }
            return sum;
        }
    }
}
