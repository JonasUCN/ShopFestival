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
        private DBProductAccess dbpa = new();
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

            List<Product> products = getAllProductsFromAPI();
            return View(products);
        }

        public IActionResult ProductView(int id)
        {
            Product pp = DBProductAccess.GetProductFromAPIByID(1);
            return View(pp);
        }

        [HttpPost]
        public IActionResult ProductView(Product _Product)
        {
            var response = DBProductAccess.RemoveStockByID(_Product.id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                OrderLine orderLine = new OrderLine { Product = _Product, Quantity = 1 };


                _CartController.addOrderLineToCart(orderLine); //TODO Fix quantity to match the page to chose the quantity 
                string json = "";
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

                _CartController.addOrderLineToCart(new OrderLine { Product = _Product, Quantity = 1 }); //TODO Fix quantity to match the page to chose the quantity 
            }
            return View(_Product);
        }


        public ICartCon GetCartController()
        {
            return _CartController;
        }

        private List<Product> getAllProductsFromAPI()
        {
            List<Product>? products = new List<Product>();
            string url = "https://localhost:5001/api/Product/Products/";
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
            return products;
        }
    }
}
