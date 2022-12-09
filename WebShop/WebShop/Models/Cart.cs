namespace WebShop.Models
{
    public class Cart
    {
        private List<OrderLine> orderLines;

        public Cart()
        {
            orderLines = new List<OrderLine>();
        }

        public void addOrderLine(OrderLine orderLine)
        {
            orderLines.Add(orderLine);
        }

        public void removeOrderLine(OrderLine orderLine)
        {
            orderLines.Remove(orderLine);
        }

        public List<OrderLine> GetOrderLines() { return orderLines; }
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
