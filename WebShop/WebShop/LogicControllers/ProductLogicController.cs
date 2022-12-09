using WebShop.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;
using WebShop.ServiceLayer;

namespace WebShop.LogicControllers
{
    public class ProductLogicController : IProductLogicController
    {
        private IOrderLineLogicController orderLineLogicController;
        private readonly DBProductAccess _DBProductAccess;
        public ProductLogicController(IConfiguration inConfiguration)
        {
            _DBProductAccess= new DBProductAccess(inConfiguration);
            orderLineLogicController = new OrderLineLogicController(inConfiguration);
        }
        public List<Product> GetProductsFromService()
        {
            List<Product> products = _DBProductAccess.getAllProductsFromAPI();
            return products;
        }

        public Product GetProductFromServiceByID(int id)
        {
            Product product = _DBProductAccess.GetProductFromAPIByID(id);
            return product;
        }

        public List<Product> AddProductToCart(int id, HttpContext http)
        {
            List<Product> Products = _DBProductAccess.getAllProductsFromAPI();

            foreach (var i in Products)
            {
                if (i.id == id)
                {
                    Product product = i;
                    OrderLine orderLine2 = new OrderLine { Product = product, Quantity = 1 };
                    orderLineLogicController.CreateNewOrderlines(orderLine2);
                    orderLineLogicController.CheckExistingOrderLine(http, orderLine2);
                    break;
                }
            }
            return Products;
        }

        public Product addProductToOrder(Product _Product, HttpContext http)
        {
            var response = _DBProductAccess.RemoveStockByID(_Product.id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                OrderLine orderLine = new OrderLine { Product = _Product, Quantity = 1 };
                orderLineLogicController.CheckExistingOrderLine(http, orderLine);
            }
            return _Product;
        }
    }
}
