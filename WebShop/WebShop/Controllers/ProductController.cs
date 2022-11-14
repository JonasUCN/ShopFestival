using LayerController;
using Microsoft.AspNetCore.Mvc;

using ModelLayer;
using Newtonsoft.Json;
using RestSharp;
using WebShop.LogicControllers;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private CartCon _CartController;
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

        public IActionResult ProductView() //TODO Make it to take a para as int id to custom take what product to display
        {

            Product product = getProductFromAPIByID(1);

            return View(product);
        }

        [HttpPost]
        public IActionResult ProductView(Product _Product)
        {
            string url = "https://localhost:5001/api/Product/RemoveStock/" + _Product.id;
            var client = new RestClient(url);
            var response = client.Post(new RestRequest());

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

            }
            return View(_Product);
        }

        public ICartCon GetCartController()
        {
            return _CartController;
        }

        private Product getProductFromAPIByID(int id)
        {
            string url = "https://localhost:5001/api/Product/Products/" + id;
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            Product product = JsonConvert.DeserializeObject<Product>(response.Content);

            return product;
        }
    }
}
