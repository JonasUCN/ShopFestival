using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.ModelLayer;

namespace DesktopApp.ServiceLayer
{
    /// <summary>
    /// This is the ISaleOrderAccess interface.
    /// It defines a set of methods for accessing sale order data.
    /// </summary>
    public interface ISaleOrderAccess
    {
        /// <summary>
        /// Gets a list of all sale orders in the database.
        /// </summary>
        /// <returns>A list of all sale orders in the database.</returns>
        public List<SaleOrder> GetAllSaleOrder();

        /// <summary>
        /// Converts a JSON string containing sale order data into a list of SaleOrder objects.
        /// </summary>
        /// <param name="content">The JSON string to convert.</param>
        /// <returns>A list of SaleOrder objects representing the data in the JSON string.</returns>
        public List<SaleOrder> ConvertJSONToListOfSaleOrders(string content);
    }
}
