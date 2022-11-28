using Database_Service.LogicController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace Database_Service.Controllers
{
    [Route("api/SaleOrder")]
    [ApiController]
    public class SaleOrderController : Controller
    {

        private SaleOrderLogicController _SaleOrderController;

        public SaleOrderController()
        {
            _SaleOrderController = new SaleOrderLogicController();
        }
        [Authorize]
        [HttpGet, Route("SaleOrders")]
        public async Task<ActionResult<List<SaleOrder>>> Get()
        {
            List<SaleOrder> saleOrders = await _SaleOrderController.GetAllSaleOrders();
            ActionResult<List<SaleOrder>> foundReturn;
            if (saleOrders.Count > 0)
            {
                foundReturn = Ok(saleOrders);
            }
            else
            {
                foundReturn = NotFound();
            }

            return foundReturn;
        }

        [Authorize]
        [HttpPost, Route("AddOrder/{id}")]
        public async Task AddOrder(string id)
        {
            bool status = await _SaleOrderController.CreateSaleOrder(id);
            if(status)
            {
                Response.StatusCode = 404;
               return;
            }
            Response.StatusCode = 200;
            return;
        }
        [Authorize]
        // GET: SaleOrderController
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        // GET: SaleOrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        // GET: SaleOrderController/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: SaleOrderController/Create
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
        // GET: SaleOrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [Authorize]
        // POST: SaleOrderController/Edit/5
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
        // GET: SaleOrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        [Authorize]
        // POST: SaleOrderController/Delete/5
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
