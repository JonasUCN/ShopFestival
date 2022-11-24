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
        private ProductLogicController _ProductLogicController = new();
        private OrderLineLogicController OrderLineLogicController;

        public ProductController()
        {
            OrderLineLogicController = new OrderLineLogicController();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductsView() //TODO Lav kald til LogicController. LogicController Laver kald til ServiceLayer
        {
            List<Product> products = _ProductLogicController.GetProductsFromService();
            return View(products);
        }

        public IActionResult ProductView(int id)
        {
            Product pp = _ProductLogicController.GetProductFromServiceByID(id);
            return View(pp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ProductsView(int id) //TODO Flyttes ned i LogicControllers. Kaldes her.
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
