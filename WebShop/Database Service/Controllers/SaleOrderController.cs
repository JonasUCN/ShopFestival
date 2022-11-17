using Database_Service.LogicController;
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


        [HttpPost, Route("AddOrder/{id}")]
        public async Task<int> AddOrder(int id)
        {
            int orderNo = await _SaleOrderController.CreateSaleOrder(id);
            if(orderNo <= 0)
            {
                Response.StatusCode = 404;
               return 0;
            }
            Response.StatusCode = 200;
            return orderNo;
        }




        // GET: SaleOrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SaleOrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleOrderController/Create
        public ActionResult Create()
        {
            return View();
        }

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

        // GET: SaleOrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

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

        // GET: SaleOrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

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
