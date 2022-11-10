
using DesktopApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;


namespace DesktopApp.Controller
{
    public class SaleOrderController
    {
        private SaleOrderAccess dataAccess = new SaleOrderAccess();
        public async Task<List<SaleOrder>> GetAllSaleOrders()
        {

            List<SaleOrder> saleOrders = await dataAccess.GetAllSaleOrderAsync();
            return saleOrders;
        }


        public async Task<List<SaleOrder>> GetActiveSaleOrderes()
        {
            List<SaleOrder> saleOrders =  await dataAccess.GetAllSaleOrderAsync();
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
