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
    }
}
