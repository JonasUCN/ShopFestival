using Database_Service.DataAccess;
using ModelLayer;

namespace Database_Service.LogicController
{
    public class SaleOrderLogicController
    {
        DBAccessSaleOrder _DBAccessSaleOrder;

        public SaleOrderLogicController()
        {
            _DBAccessSaleOrder = new();
        }

        public async Task<List<SaleOrder>> GetAllSaleOrders()
        {
            List<SaleOrder> saleOrder = await _DBAccessSaleOrder.GetAllSaleOrders();
            return saleOrder;

        }

    }
}
