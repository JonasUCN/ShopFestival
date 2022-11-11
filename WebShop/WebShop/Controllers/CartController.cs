using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LayerController;
using ModelLayer;
using Newtonsoft.Json;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartCon service;
        public CartController([FromServices] ICartCon cartCon)
        {
            service = cartCon;
        }

        [Route("myCart")]

        // GET: CartController
        [HttpGet]
        public ActionResult CartView()
        {
            OrderLine orderLine = JsonConvert.DeserializeObject<OrderLine>( HttpContext.Session.GetString("OrderLine"));
            List<OrderLine> orders = new List<OrderLine>();
            orders.Add(orderLine);

            return View(orders);
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
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

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
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

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
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
