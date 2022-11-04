using Database_Service.DataAccess;
using Model;

namespace Database_Service.LogicController
{
    public class LogicSaleOrderController
    {
        private readonly DBAccessSaleOrder dBAccessSaleOrder;

        public LogicSaleOrderController()
        {
            dBAccessSaleOrder = new DBAccessSaleOrder();
        }


        public async Task<List<SaleOrder>> GetAllSaleOrders()
        {
            List<SaleOrder> saleOrders = await dBAccessSaleOrder.GetAllSaleOrders();
            return saleOrders;

        }
    }
}
