using DesktopApp.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.LogicControllers
{
    internal interface ISaleOrderController
    {
        List<SaleOrder> GetAllSaleOrders();

        List<SaleOrder> GetActiveSaleOrderes();


    }
}
