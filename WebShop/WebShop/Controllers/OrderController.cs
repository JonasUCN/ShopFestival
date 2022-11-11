using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        
        public IActionResult OrderView()
        {
            

            return View();
        }
    }
}
