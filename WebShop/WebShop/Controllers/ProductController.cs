using LayerController;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
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
            List<Product> Products = DBProductAccess.getAllProductsFromAPI();

            foreach (var i in Products)
            {
                if (i.id == id)
                {
                    Product product = i;
                    OrderLine orderLine2 = new OrderLine { Product = product, Quantity = 1 };
                    OrderLineLogicController.CreateNewOrderlines(orderLine2);
                    OrderLineLogicController.CheckExistingOrderLine(HttpContext, orderLine2);
                    break;
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
                json = OrderLineLogicController.CheckExistingOrderLine(HttpContext,orderLine);
            }
            return View(_Product);
        }

        public ICartCon GetCartController()
        {
            return _CartController;
        }
    }
}
