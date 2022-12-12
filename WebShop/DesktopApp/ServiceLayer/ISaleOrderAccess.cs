using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.ModelLayer;

namespace DesktopApp.ServiceLayer
{
    public interface ISaleOrderAccess
    {
        public List<SaleOrder> GetAllSaleOrder();

        public List<SaleOrder> ConvertJSONToListOfSaleOrders(string content);
    }
}
