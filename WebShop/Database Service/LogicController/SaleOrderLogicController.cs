using Database_Service.DataAccess;
using ModelLayer;
using Newtonsoft.Json;

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

        public async Task<bool> CreateSaleOrder(string json)
        {
            SaleOrder saleOrder = JsonConvert.DeserializeObject<SaleOrder>(json);
            bool status = await _DBAccessSaleOrder.CreateSaleOrder(saleOrder);
            return status;
        }

    }
}
