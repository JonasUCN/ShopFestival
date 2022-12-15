using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ModelLayer
{
    /// <summary>
    /// A shopping cart.
    /// </summary>
    public class Cart
    {
        private List<OrderLine> orderLines;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cart"/> class.
        /// </summary>
        public Cart()
        {
            orderLines = new List<OrderLine>();
        }

        /// <summary>
        /// Adds an <see cref="OrderLine"/> to the cart.
        /// </summary>
        /// <param name="orderLine">The <see cref="OrderLine"/> to add.</param>
        public void addOrderLine(OrderLine orderLine)
        {
            orderLines.Add(orderLine);
        }

        /// <summary>
        /// Removes an <see cref="OrderLine"/> from the cart.
        /// </summary>
        /// <param name="orderLine">The <see cref="OrderLine"/> to remove.</param>
        public void removeOrderLine(OrderLine orderLine)
        {
            orderLines.Remove(orderLine);
        }

        /// <summary>
        /// Gets the list of <see cref="OrderLine"/> objects in the cart.
        /// </summary>
        /// <returns>The list of <see cref="OrderLine"/> objects in the cart.</returns>
        public List<OrderLine> GetOrderLines() { return orderLines; }
    }
}