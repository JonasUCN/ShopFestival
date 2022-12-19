namespace WebShop.Models
{
    public class ModelCartView
    {
        public ModelCartView()
        {
            OrderLines = new();
        }

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
