using Microsoft.AspNetCore.Identity;
//using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WebShop.LogicControllers;
using WebShop.Models;

namespace UnitTest
{
    
    public class TestOrderLineLogicController
    {

        //[Fact]
        //public void Test_CreateNewOrderlines_Susses()
        //{
        //    //arrange
        //    OrderLineLogicController orderLineLogicController = new();
        //    OrderLine orderLine = new() { Product=  new Product(){ id = 1, Brand = "addias", Price= 22m, ProductDesc = "Descrption", Stock=22,Title= "telt" }, Quantity = 11 };
        //    //act
        //    string Result =  orderLineLogicController.CreateNewOrderlines(orderLine);
        //    bool result; 
           
        //    try
        //    {
        //        var obj = JToken.Parse(Result);
        //        result = true; 

        //    }
        //    catch (JsonReaderException jex)
        //    {

        //        result = false; 
        //    }
        //    //assert
        //    Assert.True(result);

            
        //}


        //[Fact]
        //public void Test_AddToExcistingOrderLines_Succes()
        //{
        //    //arrange
        //    OrderLineLogicController orderLineLogicController = new();
        //    OrderLine orderLine = new() { Product = new Product() { id = 1, Brand = "addias", Price = 22m, ProductDesc = "Descrption", Stock = 22, Title = "telt" }, Quantity = 11 };
        //    List<OrderLine> orderLines = new List<OrderLine>();
        //    string json = JsonConvert.SerializeObject(orderLines);

        //    //act

        //    string ResultJson = orderLineLogicController.AddToExcistingOrderLines(json, orderLine);

        //    var result  =  JsonConvert.DeserializeObject<List<OrderLine>>(ResultJson);


        //    //assert
        //    Assert.Equal(orderLine, result[0]);
        //}

    }
}
