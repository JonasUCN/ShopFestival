//using AspNetCore;
using LayerController;
using Microsoft.AspNetCore.Mvc;

using ModelLayer;
using Newtonsoft.Json;
using RestSharp;
using WebShop.LogicControllers;
using WebShop.DBAccess;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {

        private CartCon _CartController = new();
        private OrderLineLogicController OrderLineLogicController;

        public ProductController()
        {
            _CartController = new CartCon();
            OrderLineLogicController = new OrderLineLogicController();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductsView()
        {
            List<Product> products = DBProductAccess.getAllProductsFromAPI();
            return View(products);
        }

        public IActionResult ProductView()
        {
            Product pp = DBProductAccess.GetProductFromAPIByID(1);
            return View(pp);
        }

        [HttpPost]
        public IActionResult ProductsView(int id)
        {
            List<Product> Products = getAllProductsFromAPI();
            bool found = false;
            int index = 0;
            while (found == false)
            {
                Product product = Products[index];
                if (product.id == id)
                {
                    OrderLine orderLine = new OrderLine { Product = product, Quantity = 1 };
                    OrderLineLogicController.CreateNewOrderlines(orderLine);
                    string json = "";
                    json = CheckExistingOrderLine(orderLine);
                    found = true;
                }
                else
                {
                    index++;
                }
            }
            return View(Products);
        }

        [HttpPost]
        public IActionResult ProductView(Product _Product)
        {
            var response = DBProductAccess.RemoveStockByID(_Product.id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                OrderLine orderLine = new OrderLine { Product = _Product, Quantity = 1 };

                string json = "";
                json = CheckExistingOrderLine(orderLine);
            }
            return View(_Product);
        }

        private string CheckExistingOrderLine(OrderLine orderLine)
        {
            string json;
            if (HttpContext.Session.GetString("OrderLines") == null)
            {
                json = OrderLineLogicController.CreateNewOrderlines(orderLine);
            }
            else
            {
                string JsonOrderlines = HttpContext.Session.GetString("OrderLines");
                json = OrderLineLogicController.AddToExcistingOrderLines(JsonOrderlines, orderLine);

            }
            HttpContext.Session.SetString("OrderLines", json);
            return json;
        }

        public ICartCon GetCartController()
        {
            return _CartController;
        }
    }
}
