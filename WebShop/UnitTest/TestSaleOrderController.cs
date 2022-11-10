using DesktopApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.Controller;

namespace UnitTest
{
    public class TestSaleOrderController
    {

        [Fact]
        public async void TestGetAllSaleOrders_isObjectValid()
        {
            //arrange
            SaleOrderController saleOrderController = new();
            //act
            var saleorders = await saleOrderController.GetAllSaleOrders();
            //assert
            Assert.IsType<List<SaleOrder>>(saleorders);

        }

        [Fact]
        public async void TestGetAllActiveSaleOrders()
        {
            //arrange
            SaleOrderController saleOrderController = new();
            //act
            var saleOrders = await saleOrderController.GetActiveSaleOrderes();

            //assert
            foreach (var SaleOrder in saleOrders)
            {
                Assert.Equal(SaleOrder.Status, "Active");
            }
            
        }


    }
}
