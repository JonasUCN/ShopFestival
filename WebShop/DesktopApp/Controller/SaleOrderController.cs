using Database_Service.DataAccess;
using DesktopApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace DesktopApp.Controller
{
    public class SaleOrderController
    {
        private OrderAccess dataAccess = new OrderAccess();
        public async Task<List<SaleOrder>> GetSaleOrder()
        {

            List<SaleOrder> saleOrders = await dataAccess.GetAllSaleOrderAsync();
            return saleOrders;
        }


        public List<SaleOrder> GetActiveSaleOrderes()
        {
            List<SaleOrder> saleOrders = dataAccess.GetActiveSaleOrders();
            List<SaleOrder> returnSaleOrder = new List<SaleOrder>() ; 
            foreach (var item in saleOrders)
            {
                if (string.Equals(item.Status,"Active"))
                {
                    returnSaleOrder.Add(item);
                }
            }
            return returnSaleOrder;
        }
           

    }
    
    
}
