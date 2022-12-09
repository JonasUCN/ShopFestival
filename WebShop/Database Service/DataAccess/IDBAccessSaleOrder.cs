using Database_Service.Model;

namespace Database_Service.DataAccess
{
    public interface IDBAccessSaleOrder
    {
        Task<List<SaleOrder>> GetAllSaleOrders();
        Task<bool> CreateSaleOrder(SaleOrder saleOrder);
        //Task CreateOrderLine(SaleOrder saleOrder);

    }
}
