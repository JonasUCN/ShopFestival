using Database_Service.Model;

namespace Database_Service.DataAccess
{
    /// <summary>
    /// Interface for accessing SaleOrder data in a database
    /// </summary>
    public interface IDBAccessSaleOrder
    {
        /// <summary>
        /// Get all SaleOrders from the database
        /// </summary>
        Task<List<SaleOrder>> GetAllSaleOrders();

        /// <summary>
        /// Create a new SaleOrder in the database
        /// </summary>
        Task<bool> CreateSaleOrder(SaleOrder saleOrder);

        // The following method is commented out because it is not implemented:
        //Task CreateOrderLine(SaleOrder saleOrder);
    }
}
