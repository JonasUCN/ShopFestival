using WebShop.Models;
using Newtonsoft.Json;
using WebShop.ServiceLayer;

namespace WebShop.LogicControllers
{
    public class OrderLogicController : IOrderLogicController
    {
        private DBSaleOrderAccess DBSaleOrderAccess = new();
        public SaleOrder CreateSaleOrder(SaleOrder mov)
        {
            SaleOrder saleOrder = new SaleOrder();

            saleOrder.orderLines = mov.orderLines;
            saleOrder.customer = mov.customer;
            //saleOrder.customer.CustomerNo = 2;

            return saleOrder;
        }

        public void AddSaleOrderToDB(SaleOrder mov)
        {
            DBSaleOrderAccess.addSaleOrder(ConvertSaleOrderToJson(CreateSaleOrder(mov)));
        }

        public string ConvertSaleOrderToJson(SaleOrder saleOrder)
        {
            string jsonString;

            jsonString = JsonConvert.SerializeObject(saleOrder);

            return jsonString;
        }
    }
}
