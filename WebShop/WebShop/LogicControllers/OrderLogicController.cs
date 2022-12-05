using ModelLayer;
using ModelLayer.DTO;
using Newtonsoft.Json;
using WebShop.Services;

namespace WebShop.LogicControllers
{
    public class OrderLogicController
    {
        private DBSaleOrderAccess DBSaleOrderAccess = new();
        public SaleOrder CreateSaleOrder(ModelOrderView mov)
        {
            SaleOrder saleOrder = new SaleOrder();

            saleOrder.orderLines = mov.orderLines;
            saleOrder.customer = mov.customer;
            saleOrder.customer.CustomerNo = 2;

            return saleOrder;
        }

        public void AddSaleOrderToDB(ModelOrderView mov, System.Security.Claims.ClaimsPrincipal user)
        {
            DBSaleOrderAccess.addSaleOrder(ConvertSaleOrderToJson(CreateSaleOrder(mov)),user);
        }

        public string ConvertSaleOrderToJson(SaleOrder saleOrder)
        {
            string jsonString;

            jsonString = JsonConvert.SerializeObject(saleOrder);

            return jsonString;
        }
    }
}
