using Database_Service.Model;

namespace Database_Service.DTO
{
    public class CartReadDTO
    {
        public List<OrderLine> OrderLines { get; set; }
        public bool Loggedin { get; set; }

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
