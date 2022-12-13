using DesktopApp.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.LogicControllers;
using DesktopApp.ModelLayer;
using Newtonsoft.Json;

namespace UnitTest.Desktop
{
    public class TestSaleOrderControllerDesktop
    {


        [Fact]
        public void TestGetAllSaleOrders_isObjectValid()
        {
            //arrange
            SaleOrderController saleOrderController = new(new FakeSaleOrderAccess());
            //act
            var saleorders = saleOrderController.GetAllSaleOrders();
            //assert
            Assert.IsType<List<SaleOrder>>(saleorders);

        }

        [Fact]
        public void TestGetAllActiveSaleOrders()
        {
            //arrange
            SaleOrderController saleOrderController = new(new FakeSaleOrderAccess());
            //act
            var saleOrders = saleOrderController.GetActiveSaleOrderes();

            //assert
            foreach (var SaleOrder in saleOrders)
            {
                Assert.Equal(SaleOrder.Status, "Active");
            }

        }

        public class FakeSaleOrderAccess : ISaleOrderAccess
        {
            public List<SaleOrder> ConvertJSONToListOfSaleOrders(string content)
            {
                return JsonConvert.DeserializeObject<List<SaleOrder>>(content);
            }

            public List<SaleOrder> GetAllSaleOrder()
            {
                List<SaleOrder> saleOrders = new List<SaleOrder>();
                saleOrders.Add(new SaleOrder() { OrderNo = 1, Status = "Aktive" });
                saleOrders.Add(new SaleOrder() { OrderNo = 2, Status = "Aktive" });
                saleOrders.Add(new SaleOrder() { OrderNo = 3, Status = "Aktive" });

                return saleOrders;
            }
        }

    }
}
