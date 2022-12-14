using Microsoft.AspNetCore.Identity;
using WebShop.Models;

namespace WebShop.LogicControllers
{
    /// <summary>
    /// Defines methods for managing orders in a web shop application.
    /// </summary>
    public interface IOrderLogicController
    {
        /// <summary>
        /// Creates a new SaleOrder object.
        /// </summary>
        /// <param name="mov">The SaleOrder to be created.</param>
        /// <param name="user">The user associated with the SaleOrder.</param>
        /// <returns>The created SaleOrder object.</returns>
        SaleOrder CreateSaleOrder(SaleOrder mov, IdentityUser user);

        /// <summary>
        /// Adds a SaleOrder to the database.
        /// </summary>
        /// <param name="mov">The SaleOrder to be added.</param>
        /// <param name="user">The user associated with the SaleOrder.</param>
        void AddSaleOrderToDB(SaleOrder mov, IdentityUser user);

        /// <summary>
        /// Converts a SaleOrder object to a JSON string.
        /// </summary>
        /// <param name="saleOrder">The SaleOrder to be converted.</param>
        /// <returns>A JSON string representing the provided SaleOrder.</returns>
        string ConvertSaleOrderToJson(SaleOrder saleOrder);
    }
}
