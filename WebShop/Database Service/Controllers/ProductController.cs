using Database_Service.DataAccess;
using Database_Service.LogicController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Database_Service.Model;

namespace Database_Service.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private LogicProductController _ProductController;

        /// <summary>
        /// Initializes a new instance of the ProductController class.
        /// </summary>
        public ProductController()
        {
            _ProductController = new LogicProductController(dBAccessProduct);
        }

        /// <summary>
        /// Returns a list of all products in the database.
        /// </summary>
        /// <returns>A list of Product objects.</returns>
        [HttpGet,Route("Products")]
        [Authorize]
        public async Task<ActionResult<List<Product>>> Get()
        {
            List<Product> p = await _ProductController.GetAllProducts();
            ActionResult<List<Product>> foundReturn;
            if(p.Count > 0)
            {
                foundReturn = Ok(p);
            }
            else
            {
                foundReturn = NotFound();
            }
            
            return foundReturn;
        }

        /// <summary>
        /// Returns a specific product from the database.
        /// </summary>
        /// <param name="id">The ID of the product to be returned.</param>
        /// <returns>A Product object.</returns>
        [Authorize]
        [HttpGet, Route("Products/{id}")]
        public async Task<Product> Get(int id)
        {
            var product = await _ProductController.GetProductByID(id);
            return product;
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>An HTTP status code indicating the result of the operation.</returns>
        [Authorize]
        [HttpPost, Route("Create")]
        public async Task<ActionResult> PostNewProduct(Product product)
        {
            ActionResult wasCreated;
            bool success = await _ProductController.CreateProduct(product);
            if (success)
            {
                wasCreated = Ok();
            }
            else
            {
                wasCreated = new StatusCodeResult(500);
            }
            return wasCreated;
        }


        /// <summary>
        /// Increases the stock of a product with the given ID.
        /// </summary>
        /// <param name="id">The ID of the product to increase the stock of.</param>
        /// <returns>An HTTP status code indicating the result of the operation.</returns>
        [Authorize]
        [HttpPost, Route("IncreaseStock/{id}")]
        public async void IncreaseStockFromProductById(int id)
        {
            bool state = await _ProductController.IncreaseStockOnProductById(id);
            if (state)
            {
                Response.StatusCode = 200;
                return;
            }
            Response.StatusCode = 404;
            return;
        }

        /// <summary>
        /// Gets the details of a product with the given ID.
        /// </summary>
        /// <param name="id">The ID of the product to get the details of.</param>
        /// <returns>A view containing the details of the product.</returns>
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }
        /// <summary>
        /// Gets the page for creating a new product.
        /// </summary>
        /// <returns>A view for creating a new product.</returns>
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="collection">The form data for the new product.</param>
        /// <returns>A redirect to the product index page, or a view containing the create form if an error occurred.</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// Retrieves the product with the specified ID for editing.
        /// </summary>
        /// <param name="id">The ID of the product to edit.</param>
        /// <returns>The view for editing the product.</returns>
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// Updates the product with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="collection">The updated product data.</param>
        /// <returns>The view for the updated product.</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Retrieves the product with the specified ID for deletion.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>The view for deleting the product.</returns>
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// Deletes the product with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <param name="collection">The product data to be deleted.</param>
        /// <returns>The view for the deleted product.</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
