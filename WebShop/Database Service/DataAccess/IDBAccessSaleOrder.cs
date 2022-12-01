using ModelLayer;

namespace Database_Service.DataAccess
{
    public interface IDBAccessSaleOrder
    {
        Task<List<SaleOrder>> GetAllSaleOrders();
        Task<int> CreateSaleOrder(SaleOrder saleOrder);
        Task CreateOrderLine(SaleOrder saleOrder);

    }
}
