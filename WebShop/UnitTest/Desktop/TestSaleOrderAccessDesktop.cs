using DesktopApp.ModelLayer;
using DesktopApp.ServiceLayer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Desktop
{
    public class TestSaleOrderAccessDesktop
    {
        Microsoft.Extensions.Configuration.IConfiguration configuration;
        [Fact]
        public void TestGetAllSaleOrders_isObjectValid()
        {
            //arrange
            SaleOrderAccess _SaleOrdersAccess = new(configuration);
            //act
            var saleorders = _SaleOrdersAccess.GetAllSaleOrder();
            //assert
            Assert.IsType<List<SaleOrder>>(saleorders);

        }

        [Theory]
        [InlineData("", false)]
        [InlineData("[\r\n    {\r\n        \"orderNo\": 1,\r\n        \"status\": \"Active\"\r\n    },\r\n    {\r\n        \"orderNo\": 2,\r\n        \"status\": \"Active\"\r\n    },\r\n    {\r\n        \"orderNo\": 3,\r\n        \"status\": \"Delivered\"\r\n    },\r\n    {\r\n        \"orderNo\": 4,\r\n        \"status\": \"Delivered\"\r\n    },\r\n    {\r\n        \"orderNo\": 5,\r\n        \"status\": \"Active\"\r\n    },\r\n    {\r\n        \"orderNo\": 6,\r\n        \"status\": \"Active\"\r\n    }\r\n]", true)]
        //[InlineData("[\r\n    {\r\n        \"oro\": 1  }\r\n]",false)] Need to implemet validation of JSON
        public async void ConvertJSONToListOfSaleOrders_TestJsonInput(string inputJSON, bool expected)
        {
            //arrange
            bool result;
            SaleOrderAccess saleOrderAccess = new(configuration);
            //act
            List<SaleOrder> saleOrders = saleOrderAccess.ConvertJSONToListOfSaleOrders(inputJSON);

            if (saleOrders == null)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            //assert 
            Assert.Equal(expected, result);
        }











    }
}