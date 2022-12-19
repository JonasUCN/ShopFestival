using Database_Service.DataAccess;
using Database_Service.Model;
using Newtonsoft.Json;

namespace Database_Service.LogicController
{
    public class SaleOrderLogicController
    {
        private DBAccessSaleOrder _DBAccessSaleOrder;
        private LogicProductController LogicProductController;
        public SaleOrderLogicController(IDBAccessProduct dBAccessProduct)
        {
            _DBAccessSaleOrder = new(dBAccessProduct);
            LogicProductController = new(dBAccessProduct);
        }

        /// <summary>
        /// Returns a list of all sale orders from the database.
        /// </summary>
        public async Task<List<SaleOrder>> GetAllSaleOrders()
        {
            List<SaleOrder> saleOrder = await _DBAccessSaleOrder.GetAllSaleOrders();
            return saleOrder;

        }

        // <summary>
        /// Creates a new sale order from a JSON string and saves it to the database.
        /// </summary>
        public async Task<bool> CreateSaleOrder(string json)
        {
            SaleOrder saleOrder = JsonConvert.DeserializeObject<SaleOrder>(json);
            bool status = false;
            status = await _DBAccessSaleOrder.CreateSaleOrder(saleOrder);
            return status;
        }

        // Not Used
        //private async Task CreateOrderLine(SaleOrder saleOrder)
        //{
        //    await _DBAccessSaleOrder.CreateOrderLine(saleOrder);
        //}

    }
}
