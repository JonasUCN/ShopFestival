using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;
using ModelLayer;
using Newtonsoft.Json;
using WebShop.Services;
using WebShop.LogicControllers;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;


namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        private OrderLogicController _OrderLogicController = new();

        private readonly UserManager<IdentityUser> _userManager;
        public OrderController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult OrderView()
        {
            ModelOrderView mov = new ModelOrderView();
            mov.orderLines = JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));
            var user = _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
            
            Customer c = CustomerLogicController.GetCustomerFromAPIByEmail(user.Email);

            if (c.Email == null)
                mov.customer.Email = user.Email;
            else
                mov.customer = c;


            return View(mov);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> OrderView(ModelOrderView _MOV)
        {

            System.Security.Claims.ClaimsPrincipal user = User;
                
            //TODO Add customer information from the textboxes from the checkout page to the object
            _MOV.orderLines = JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));

            _OrderLogicController.AddSaleOrderToDB(_MOV,user);

            var user = _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;

            bool val1 = (HttpContext.User != null) && HttpContext.User.Identity.IsAuthenticated;
            if (val1)
            {
                _OrderLogicController.AddSaleOrderToDB(_MOV, user);
            }


            return View(_MOV);
        }
    }
}
