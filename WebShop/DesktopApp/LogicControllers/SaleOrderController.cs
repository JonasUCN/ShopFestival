
using DesktopApp.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.ModelLayer;

namespace DesktopApp.LogicControllers
{
    /// <summary>
    /// This is the SaleOrderController class.
    /// It provides methods for managing sale orders.
    /// </summary>
    public class SaleOrderController : ISaleOrderController
    {
        /// <summary>
        /// A reference to the sale order data access object.
        /// </summary>
        private ISaleOrderAccess dataAccess;

        /// <summary>
        /// A constructor that initializes the data access object.
        /// </summary>
        /// <param name="saleOrderAccess">The sale order data access object to use.</param>
        public SaleOrderController(ISaleOrderAccess saleOrderAccess)
        {
            dataAccess = saleOrderAccess;
        }

        /// <summary>
        /// Gets a list of all sale orders.
        /// </summary>
        /// <returns>A list of sale orders.</returns>
        public List<SaleOrder> GetAllSaleOrders()
        {
            // Retrieve the sale orders from the database and return them
            List<SaleOrder> saleOrders = dataAccess.GetAllSaleOrder();
            return saleOrders;
        }

        /// <summary>
        /// Gets a list of all active (i.e. non-completed) sale orders.
        /// </summary>
        /// <returns>A list of active sale orders.</returns>
        public List<SaleOrder> GetActiveSaleOrderes()
        {
            // Retrieve all sale orders from the database
            List<SaleOrder> saleOrders = dataAccess.GetAllSaleOrder();

            // Create a list to hold the active sale orders
            List<SaleOrder> returnSaleOrder = new List<SaleOrder>();

            // Loop through the sale orders and add the active ones to the return list
            foreach (var item in saleOrders)
            {
                if (string.Equals(item.Status, "Active"))
                {
                    returnSaleOrder.Add(item);
                }
            }

            // Return the list of active sale orders
            return returnSaleOrder;
        }
    }
}