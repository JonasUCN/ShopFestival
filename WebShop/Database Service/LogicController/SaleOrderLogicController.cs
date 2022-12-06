using Database_Service.DataAccess;
using Database_Service.Model;
using Newtonsoft.Json;

namespace Database_Service.LogicController
{
    public class SaleOrderLogicController : ISaleOrderLogicController
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
            bool status = true;
            SaleOrder saleOrder = JsonConvert.DeserializeObject<SaleOrder>(json);
            int orderNo = await _DBAccessSaleOrder.CreateSaleOrder(saleOrder);
            if (orderNo <= 0)
            {
                status = false;
            }
            saleOrder.OrderNo = orderNo;
            CreateOrderLine(saleOrder);

            return status;
        }

        private async Task CreateOrderLine(SaleOrder saleOrder)
        {
            await _DBAccessSaleOrder.CreateOrderLine(saleOrder);
        }

        Task ISaleOrderLogicController.CreateOrderLine(SaleOrder saleOrder)
        {
            throw new NotImplementedException();
        }
    }
}
