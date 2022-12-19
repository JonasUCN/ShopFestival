namespace WebShop.Models
{
    public class ModelOrderView
    {
        public List<OrderLine> orderLines { get; set; }
        public Customer customer { get; set; }

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
