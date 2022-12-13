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

        public ProductController(IDBAccessProduct dBAccessProduct)
        {
            _ProductController = new LogicProductController(dBAccessProduct);
        }



        // GET: ProductController

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
        [Authorize]
        [HttpGet, Route("Products/{id}")]
        public async Task<Product> Get(int id)
        {
            var product = await _ProductController.GetProductByID(id);
            return product;
        }
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
        [Authorize]
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: ProductController/Create
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
        [Authorize]
        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [Authorize]
        // POST: ProductController/Edit/5
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
        [Authorize]
        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        [Authorize]
        // POST: ProductController/Delete/5
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
