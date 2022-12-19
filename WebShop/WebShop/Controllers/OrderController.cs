using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using Newtonsoft.Json;
using WebShop.LogicControllers;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;


namespace WebShop.Controllers
{
    /// <summary>
    /// This controller is responsible for handling requests related to orders in the web shop.
    /// </summary>
    public class OrderController : Controller
    {
        private OrderLogicController _OrderLogicController = new();

        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the `OrderController` class.
        /// </summary>
        /// <param name="userManager">The `UserManager` instance used to retrieve user information.</param>
        public OrderController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Returns a view of the current sale order, including information about the order lines
        /// and the customer who placed the order.
        /// </summary>
        /// <returns>An IActionResult representing the view of the current sale order.</returns>
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

        /// <summary>
        /// Handles a POST request for the sale order view. Adds customer information from the request
        /// to the sale order object and saves the sale order to the database.
        /// </summary>
        /// <param name="_MOV">The SaleOrder object to be updated and saved.</param>
        /// <returns>An IActionResult representing the updated sale order view.</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> OrderView(ModelOrderView _MOV)
        {       
            _MOV.orderLines = JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));

            var user = _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;

            bool val1 = (HttpContext.User != null) && HttpContext.User.Identity.IsAuthenticated;

            bool status = false;
            if (val1)
            {
               status = _OrderLogicController.AddSaleOrderToDB(_MOV, user);
            }

            if (status)
            {
                return RedirectToAction("OrderConfirmation", _MOV);
            }else
                return View("ErrorViewModel");
        }

        [Authorize]
        public async Task<IActionResult> OrderConfirmationView(ModelOrderView _MOV)
        {
            return View(_MOV);
        }
    }
}
