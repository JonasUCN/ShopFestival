using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ModelLayer
{
    
    // The SaleOrder class represents an order made by a customer, consisting of one or more order lines
    public class SaleOrder
    {
        // The unique order number for this order
        public int OrderNo { get; set; }

        // The current status of the order (e.g. "pending", "shipped", etc.)
        public string Status { get; set; }

        // The date and time when the order was made
        public DateTime OrderDate { get; set; }

        // The list of order lines in this order
        public List<OrderLine> orderLines { get; set; }

        // The customer who made this order
        public Customer customer { get; set; }

        // A default constructor that initializes the customer property
        public SaleOrder()
        {
            customer = new Customer();
        }

        /// <summary>
        /// A method that calculates and returns the total price of this order.
        /// </summary>
        /// <returns>The total price of this order as a `double`.</returns>
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