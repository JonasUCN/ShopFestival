using Database_Service.Model;

namespace Database_Service.LogicController
{
    public interface ISaleOrderLogicController
    {
        Task<List<SaleOrder>> GetAllSaleOrders();

        Task<bool> CreateSaleOrder(string json);

        Task CreateOrderLine(SaleOrder saleOrder);
    }
}
