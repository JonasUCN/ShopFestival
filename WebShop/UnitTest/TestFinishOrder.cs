using Database_Service.DataAccess;
using Database_Service.LogicController;
using DesktopApp.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Services;

namespace UnitTest
{
    public class TestFinishOrder
    {
        [Fact]
        public void AddSaleOrder_Success()
        {
            //Arrange
            bool expected = true;

            ProductAccess productAccess = new ProductAccess();
            SaleOrderLogicController saleOrderLogicController = new SaleOrderLogicController();
            SaleOrder saleOrder = new SaleOrder();
            Product p = productAccess.GetProductByID(1);
            OrderLine orderLine = new OrderLine { Product = p,Quantity=5};
            saleOrder.orderLines.Add(orderLine);
            Customer c = DBCustomerAccess.GetCustomerFromAPIByEmail("test@mail.dkk");
            saleOrder.customer = c;
            OrderAddress orderAddress = new OrderAddress { zipcode = c.ZipCode, Street = c.Street, streetNo = c.StreetNo };
            saleOrder.OrderAddress = orderAddress;
            string json = JsonConvert.SerializeObject(saleOrder);
            
            //Act
            bool result = DBSaleOrderAccess.addSaleOrder(json);
            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddSaleOrderStockTooLow_Failure()
        {
            //Arrange
            bool expected = true;

            ProductAccess productAccess = new ProductAccess();
            SaleOrderLogicController saleOrderLogicController = new SaleOrderLogicController();
            SaleOrder saleOrder = new SaleOrder();
            Product p = productAccess.GetProductByID(3);
            OrderLine orderLine = new OrderLine { Product = p, Quantity = 5 };
            saleOrder.orderLines.Add(orderLine);
            Customer c = DBCustomerAccess.GetCustomerFromAPIByEmail("test@mail.dkk");
            saleOrder.customer = c;
            OrderAddress orderAddress = new OrderAddress { zipcode = c.ZipCode, Street = c.Street, streetNo = c.StreetNo };
            saleOrder.OrderAddress = orderAddress;
            string json = JsonConvert.SerializeObject(saleOrder);

            //Act
            bool result = DBSaleOrderAccess.addSaleOrder(json);
            //Assert
            Assert.Equal(expected, result);

        }
    }
}
