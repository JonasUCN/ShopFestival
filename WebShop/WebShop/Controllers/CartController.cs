using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using Newtonsoft.Json;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        [Route("myCart")]

        // GET: CartController
        [HttpGet]
        public ActionResult CartView()
        {
            List<OrderLine> orders;
            Cart mcv = new();

            if (HttpContext.Session.GetString("OrderLines") != null)
            {
                orders = JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));
            }
            else
            {
                orders = new List<OrderLine>();
            }
            mcv.OrderLines = orders;
            mcv.Loggedin = HttpContext.User.Identity.IsAuthenticated && (HttpContext.User != null);

            return View(mcv);
        }


        [Route("myCart")]
        [HttpPost]
        public ActionResult CartView(int quantity, int id)
        {

            List<OrderLine> orders = JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));
            Cart mcv = new();

            foreach (var item in orders)
            {
                if (item.Product.id == id)
                {
                    item.Quantity = quantity;
                }

            }
            mcv.OrderLines = orders;
            mcv.Loggedin = HttpContext.User.Identity.IsAuthenticated && (HttpContext.User != null);
            string JsonOrderLines = JsonConvert.SerializeObject(orders);
            HttpContext.Session.SetString("OrderLines", JsonOrderLines);

            return View(mcv);
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