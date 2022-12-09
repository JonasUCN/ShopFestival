
using DesktopApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.ModelLayer;


namespace DesktopApp.Controller
{
    public class SaleOrderController
    {
        private ISaleOrderAccess dataAccess;
        public SaleOrderController(ISaleOrderAccess saleOrderAccess)
        {
            dataAccess = saleOrderAccess;
        }

        public List<SaleOrder> GetAllSaleOrders()
        { 
            List<SaleOrder> saleOrders = dataAccess.GetAllSaleOrder();
            return saleOrders;
        }


        public List<SaleOrder> GetActiveSaleOrderes()
        {
            List<SaleOrder> saleOrders = dataAccess.GetAllSaleOrder();
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
