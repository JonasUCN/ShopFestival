using WebShop.Models;

namespace WebShop.LogicControllers
{
    /// <summary>
    /// Defines methods for managing order lines in a web shop application.
    /// </summary>
    public interface IOrderLineLogicController
    {
        /// <summary>
        /// Creates a new OrderLine object.
        /// </summary>
        /// <param name="orderLine">The OrderLine to be created.</param>
        /// <returns>A string representing the result of the operation.</returns>
        string CreateNewOrderlines(OrderLine orderLine);

        /// <summary>
        /// Adds an OrderLine to an existing collection of OrderLines.
        /// </summary>
        /// <param name="JsonOrderLines">A JSON string representing the existing collection of OrderLines.</param>
        /// <param name="orderLine">The OrderLine to be added to the collection.</param>
        /// <returns>A string representing the result of the operation.</returns>
        string AddToExcistingOrderLines(string JsonOrderLines, OrderLine orderLine);

        /// <summary>
        /// Checks if an OrderLine already exists in the current user's order.
        /// </summary>
        /// <param name="http">The current HTTP context.</param>
        /// <param name="orderLine">The OrderLine to be checked.</param>
        /// <returns>A string representing the result of the operation.</returns>
        string CheckExistingOrderLine(HttpContext http, OrderLine orderLine);

    }
}