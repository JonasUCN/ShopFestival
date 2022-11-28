using ModelLayer;
using ModelLayer.DTO;
using Newtonsoft.Json;
using WebShop.Services;

namespace WebShop.LogicControllers
{
    public class OrderLogicController
    {
        private DBSaleOrderAccess DBSaleOrderAccess = new();
        private OrderAddress orderAddress = new OrderAddress();
        public SaleOrder CreateSaleOrder(ModelOrderView mov)
        {
            SaleOrder saleOrder = new SaleOrder();
            orderAddress = CreateOrderAddress(mov);
            saleOrder.OrderAddress = orderAddress;
            saleOrder.orderLines = mov.orderLines;
            saleOrder.customer = mov.customer;
            saleOrder.customer.CustomerNo = 2;

            return saleOrder;
        }

        public void AddSaleOrderToDB(ModelOrderView mov)
        {
            DBSaleOrderAccess.addSaleOrder(ConvertSaleOrderToJson(CreateSaleOrder(mov)));
        }

        public string ConvertSaleOrderToJson(SaleOrder saleOrder)
        {
            string jsonString;

            jsonString = JsonConvert.SerializeObject(saleOrder);

            return jsonString;
        }

        private OrderAddress CreateOrderAddress(ModelOrderView mov)
        {
            orderAddress.Street = mov.customer.Street;
            orderAddress.streetNo = mov.customer.StreetNo;
            orderAddress.zipcode = mov.customer.ZipCode;
            orderAddress.city = mov.customer.City;
            return orderAddress;
        }
    }
}
