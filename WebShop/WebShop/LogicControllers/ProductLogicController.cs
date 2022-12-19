using WebShop.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;
using WebShop.ServiceLayer;

namespace WebShop.LogicControllers
{
    /// <summary>
    /// The ProductLogicController class provides methods for managing products in a webshop.
    /// </summary>
    public class ProductLogicController : IProductLogicController
    {
        private readonly OrderLineLogicController _orderLineLogicController;
        private readonly DBProductAccess _DBProductAccess;

        /// <summary>
        /// Initializes a new instance of the ProductLogicController class with a DBProductAccess object and an OrderLineLogicController object.
        /// </summary>
        /// <param name="inConfiguration">The configuration to use for the DBProductAccess object.</param>
        public ProductLogicController(IConfiguration inConfiguration)
        {
            _DBProductAccess = new DBProductAccess(inConfiguration);
            _orderLineLogicController = new OrderLineLogicController(inConfiguration);
        }

        /// <summary>
        /// Gets a list of all products from a webservice.
        /// </summary>
        /// <returns>A list of Product objects.</returns>
        public List<Product> GetProductsFromService()
        {
            List<Product> products = _DBProductAccess.getAllProductsFromAPI();
            return products;
        }

        /// <summary>
        /// Gets a product from a webservice by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to get.</param>
        /// <returns>A Product object with the specified ID.</returns>
        public Product GetProductFromServiceByID(int id)
        {
            Product product = _DBProductAccess.GetProductFromAPIByID(id);
            return product;
        }

        /// <summary>
        /// Adds a product to the shopping cart.
        /// </summary>
        /// <param name="id">The ID of the product to add to the cart.</param>
        /// <param name="http">The HTTP context for the current request.</param>
        /// <returns>A list of all products.</returns>
        public List<Product> AddProductToCart(int id, HttpContext http)
        {
            List<Product> Products = _DBProductAccess.getAllProductsFromAPI();

            foreach (var i in Products)
            {
                if (i.id == id)
                {
                    Product product = i;
                    OrderLine orderLine2 = new OrderLine { Product = product, Quantity = 1 };
                    _orderLineLogicController.CreateNewOrderlines(orderLine2);
                    _orderLineLogicController.CheckExistingOrderLine(http, orderLine2);
                    break;
                }
            }
            return Products;
        }

        /// <summary>
        /// Adds a product to an order and reduces its stock in the webservice.
        /// </summary>
        /// <param name="_Product">The Product object to add to the order.</param>
        /// <param name="http">The HTTP context for the current request.</param>
        /// <returns>The Product object that was added to the order.</returns>
        public Product addProductToOrder(Product _Product, HttpContext http)
        {
            var response = _DBProductAccess.RemoveStockByID(_Product.id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                OrderLine orderLine = new OrderLine { Product = _Product, Quantity = 1 };
                _orderLineLogicController.CheckExistingOrderLine(http, orderLine);
            }
            return _Product;
        }
    }
}