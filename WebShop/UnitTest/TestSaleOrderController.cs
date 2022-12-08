using DesktopApp.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.LogicController;
using DesktopApp.ModelLayer;

namespace UnitTest
{
    public class TestSaleOrderController
    {

        [Fact]
        public  void TestGetAllSaleOrders_isObjectValid()
        {
            //arrange
            SaleOrderController saleOrderController = new(new SaleOrderAccess());
            //act
            var saleorders = saleOrderController.GetAllSaleOrders();
            //assert
            Assert.IsType<List<SaleOrder>>(saleorders);

        }

        [Fact]
        public  void TestGetAllActiveSaleOrders()
        {
            //arrange
            SaleOrderController saleOrderController = new(new SaleOrderAccess()) ;
            //act
            var saleOrders = saleOrderController.GetActiveSaleOrderes();

            //assert
            foreach (var SaleOrder in saleOrders)
            {
                Assert.Equal(SaleOrder.Status, "Active");
            }
            
        }


    }
}
