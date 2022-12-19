using DesktopApp.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.LogicControllers
{
    /// <summary>
    /// This is the ISaleOrderController interface
    /// It defines a set of methods for managing sale orders
    /// </summary>
    internal interface ISaleOrderController
    {
        /// <summary>
        /// Gets a list of all sale orders
        /// </summary>
        /// <returns>A list of all sale orders</returns>
        List<SaleOrder> GetAllSaleOrders();

        /// <summary>
        /// Gets a list of all active (i.e. non-completed) sale orders
        /// </summary>
        /// <returns>A list of all active sale orders</returns>
        List<SaleOrder> GetActiveSaleOrderes();
    }
}
