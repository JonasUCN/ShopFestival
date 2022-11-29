using Database_Service.DataAccess;
using ModelLayer;
using Newtonsoft.Json;

namespace Database_Service.LogicController
{
    public class SaleOrderLogicController
    {
        private DBAccessSaleOrder _DBAccessSaleOrder;
        private LogicProductController LogicProductController;
        public SaleOrderLogicController()
        {
            _DBAccessSaleOrder = new();
            LogicProductController = new();
        }

        public async Task<List<SaleOrder>> GetAllSaleOrders()
        {
            List<SaleOrder> saleOrder = await _DBAccessSaleOrder.GetAllSaleOrders();
            return saleOrder;

        }

        public async Task<bool> CreateSaleOrder(string json)
        {
            SaleOrder saleOrder = JsonConvert.DeserializeObject<SaleOrder>(json);
            Console.WriteLine(saleOrder.orderLines[0].Quantity);
            List<Product> products = LogicProductController.GetAllProducts().Result;
            bool success = true; //If the stock is not equal or higher than quantity on the products in the order bool turns false.
            bool status = false;
            foreach (var i in products)
            {
                foreach (var item in saleOrder.orderLines)
                {
                    if (i.id == item.Product.id && !(item.Quantity <= i.Stock))
                    {
                        success = false;
                    }
                }
            }
            Console.WriteLine(success + " bool");
            if (success)
            {
                status = await _DBAccessSaleOrder.CreateSaleOrder(saleOrder);
                Console.WriteLine(status);
                if (status)
                {
                   await LogicProductController.RemoveStockOnProductByOrder(saleOrder);
                }
            }
            return status;
        }

    }
}
