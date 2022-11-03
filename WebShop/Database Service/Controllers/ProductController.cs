using Database_Service.DataAccess;
using Database_Service.LogicController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using Newtonsoft.Json;

namespace Database_Service.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : Controller
    {
        LogicProductController _ProductController;

        public ProductController()
        {
            _ProductController = new LogicProductController();
        }



        // GET: ProductController

        [HttpGet,Route("Products")]
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

        [HttpGet, Route("Products/{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            ActionResult<Product> foundReturn;
            Product product = await _ProductController.GetProductByID(id);
            if (product != null)
            {
                foundReturn = Ok(product);
            }
            else
            {
                foundReturn= NotFound();
            }
            return foundReturn;
        }

        [HttpPost,Route("Create")]
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




        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

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
