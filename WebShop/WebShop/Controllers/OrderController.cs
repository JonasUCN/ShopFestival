using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;
using ModelLayer;
using Newtonsoft.Json;
using WebShop.Services;
using WebShop.LogicControllers;
using Microsoft.AspNetCore.Identity;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        private OrderLogicController _OrderLogicController = new();
        public IActionResult OrderView()
        {
            ModelOrderView mov = new ModelOrderView();
            mov.orderLines = JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));

            return View(mov);
        }

        [HttpPost]
        public IActionResult OrderView(ModelOrderView _MOV)
        {
            //TODO Add customer information from the textboxes from the checkout page to the object
            _MOV.orderLines = JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));
            var user = await _userManager
            bool val1 = (HttpContext.User != null) && HttpContext.User.Identity.IsAuthenticated;
            if (val1)
            {
                _OrderLogicController.AddSaleOrderToDB(_MOV);
            }

            return View(_MOV);
        }
    }
}
