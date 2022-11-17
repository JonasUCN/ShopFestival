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
        public CartController( ICartCon cartCon)
        {
            service = cartCon;
        }
        [Route("myCart")]

        // GET: CartController
        [HttpGet]
        public ActionResult CartView()
        {
            
            List<OrderLine> orders = new List<OrderLine>(); 
            if(HttpContext.Session.GetString("OrderLines") != null)
            {
                JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));
            }
            
            return View(orders);
        }

          
        [Route("myCart")]
        [HttpPost]

        public ActionResult CartView(int quantity, int id)
        {

            List<OrderLine> orders = JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));

            foreach (var item in orders)
            {
                if(item.Product.id == id)
                {
                    item.Quantity = quantity;
                }
                
            }

            string JsonOrderLines = JsonConvert.SerializeObject(orders);
            HttpContext.Session.SetString("OrderLines", JsonOrderLines);

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
