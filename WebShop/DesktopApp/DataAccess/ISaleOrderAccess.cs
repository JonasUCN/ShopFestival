using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DataAccess
{
    public interface ISaleOrderAccess
    {
        public List<SaleOrder> GetAllSaleOrder();

        public List<SaleOrder> ConvertJSONToListOfSaleOrders(string content);
    }
}
