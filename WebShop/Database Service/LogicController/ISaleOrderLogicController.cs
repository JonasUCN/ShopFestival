using Database_Service.Model;

namespace Database_Service.LogicController
{
    public interface ISaleOrderLogicController
    {
        /// <summary>
        /// Retrieves a list of all sale orders in the database.
        /// </summary>
        /// <returns>A list of sale orders.</returns>
        Task<List<SaleOrder>> GetAllSaleOrders();

        /// <summary>
        /// Adds a new sale order to the database.
        /// </summary>
        /// <param name="json">A JSON string containing the data for the sale order to add.</param>
        /// <returns>True if the sale order was added successfully, false otherwise.</returns>
        Task<bool> CreateSaleOrder(string json);

        // Not Implemented
        //Task CreateOrderLine(SaleOrder saleOrder);
    }
}
