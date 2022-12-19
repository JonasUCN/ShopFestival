using Database_Service.LogicController;
using Database_Service.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Database_Service.Model;
using Database_Service.DataAccess;

namespace Database_Service.Controllers
{
    /// <summary>
    /// The `SaleOrderController` class is a `Controller` that handles HTTP requests for the `SaleOrder` API.
    /// </summary>
    [Route("api/SaleOrder")]
    [ApiController]
    public class SaleOrderController : Controller
    {
        private SaleOrderLogicController _SaleOrderController;


        /// <summary>
        /// The constructor for the `SaleOrderController` class.
        /// </summary>
        public SaleOrderController()
        {
            _SaleOrderController = new SaleOrderLogicController(dBAccessProduct);
        }

        /// <summary>
        /// Handles HTTP GET requests for the `SaleOrder` API.
        /// </summary>
        /// <returns>A list of `SaleOrder` objects, or a `404 Not Found` if no sale orders were found.</returns>
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

        /// <summary>
        /// Adds an order with the specified ID.
        /// </summary>
        /// <param name="Authorization">The authorization header.</param>
        /// <param name="id">The ID of the order to add.</param>
        [Authorize]
        [HttpPost, Route("AddOrder/{id}")]
        public async Task AddOrder([FromHeader] string Authorization, string id)
        {
            

            var authHeader = this.HttpContext.Request.Headers.Authorization.ToString();
            bool AuthorizeSuccess = JwtToken.ValidateGrantType(authHeader);

            if (AuthorizeSuccess)
            {
                bool status = await _SaleOrderController.CreateSaleOrder(id);
                if (status)
                {
                    Response.StatusCode = 404;
                    return;
                }
                Response.StatusCode = 200;
                return;
            }
            else
            {
                Response.StatusCode = 401;
                return;
            }
            

        }

        /// <summary>
        /// Displays the default page. This action is only accessible to authenticated users.
        /// </summary>
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Displays the details for the item with the specified ID. This action is only accessible to authenticated users.
        /// </summary>
        /// <param name="id">The ID of the item to display.</param>
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Displays the page for creating a new item. This action is only accessible to authenticated users.
        /// </summary>
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Handles the creation of a new item. This action is only accessible to authenticated users.
        /// </summary>
        /// <param name="collection">The form data for the new item.</param>
        /// <returns>
        /// A <see cref="RedirectToActionResult"/> object that redirects to the <see cref="Index"/> action
        /// if the item is successfully created, or a <see cref="ViewResult"/> object if an error occurs.
        /// </returns>
        [Authorize]
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

        /// <summary>
        /// This action method allows authorized users to edit an item with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the item to edit.</param>
        /// <returns>The view for editing the item.</returns>
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// This action method allows authorized users to save the changes they made to an item with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the item that was edited.</param>
        /// <param name="collection">The form collection containing the edited item data.</param>
        /// <returns>A redirect to the index action.</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // Save the changes to the item.
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// This action method allows users to view the confirmation page for deleting an item with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <returns>The view for deleting the item.</returns>
        [Authorize]       
        public ActionResult Delete(int id)
        {
            return View();
        }
        /// <summary>
        /// This action method allows authorized users to delete an item with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <param name="collection">The form collection containing the deletion confirmation.</param>
        /// <returns>A redirect to the index action.</returns>
        [Authorize]
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
