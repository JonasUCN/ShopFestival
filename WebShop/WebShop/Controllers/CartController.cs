using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using Newtonsoft.Json;

namespace WebShop.Controllers
{
    /// <summary>
    /// This class defines a controller for managing a user's shopping cart.
    /// </summary>
    public class CartController : Controller
    {
        /// <summary>
        /// This method handles HTTP GET requests to the myCart route, and
        /// returns a view that shows the items in the user's cart.
        /// </summary>
        /// <returns>A view that displays the items in the user's cart.</returns>
        [Route("myCart")]
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

        /// <summary>
        /// This action method updates the quantity of an item in the cart.
        /// </summary>
        /// <param name="quantity">The updated quantity of the item.</param>
        /// <param name="id">The id of the item to be updated.</param>
        /// <returns>The updated cart view.</returns>
        [Route("myCart")]
        [HttpPost]
        public ActionResult CartView(int quantity, int id)
        {
            // Deserialize the order lines from the session
            List<OrderLine> orders = JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));
            Cart mcv = new();

            // Update the quantity of the item with the specified id
            foreach (var item in orders)
            {
                if (item.Product.id == id)
                {
                    item.Quantity = quantity;
                }

            }
            mcv.OrderLines = orders;
            // Check if the user is logged in
            mcv.Loggedin = HttpContext.User.Identity.IsAuthenticated && (HttpContext.User != null);
            // Serialize the updated order lines and store them in the session
            string JsonOrderLines = JsonConvert.SerializeObject(orders);
            HttpContext.Session.SetString("OrderLines", JsonOrderLines);

            return View(mcv);
        }

        /// <summary>
        /// This action method displays the details of an item in the cart.
        /// </summary>
        /// <param name="id">The id of the item to display the details for.</param>
        /// <returns>The details view of the specified item.</returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// This action method displays the view for creating a new item in the cart.
        /// </summary>
        /// <returns>The create view.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// This action method creates a new item in the cart.
        /// </summary>
        /// <param name="collection">The form collection containing the details of the item to be added to the cart.</param>
        /// <returns>The index view if the item is successfully added, the create view otherwise.</returns>
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
        /// This action method displays the view for editing an item in the cart.
        /// </summary>
        /// <param name="id">The id of the item to be edited.</param>
        /// <returns>The edit view for the specified item.</returns>
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// This action method edits an existing item in the cart.
        /// </summary>
        /// <param name="id">The id of the item to be edited.</param>
        /// <param name="collection">The form collection containing the updated details of the item.</param>
        /// <returns>The index view if the item is successfully edited, the edit view otherwise.</returns>
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

        /// <summary>
        /// This action method displays the view for deleting an item from the cart.
        /// </summary>
        /// <param name="id">The id of the item to be deleted.</param>
        /// <returns>The delete view for the specified item.</returns>
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// This action method deletes an item from the cart.
        /// </summary>
        /// <param name="id">The id of the item to be deleted.</param>
        /// <param name="collection">The form collection containing the details of the item to be deleted.</param>
        /// <returns>The index view if the item is successfully deleted, the delete view otherwise.</returns>
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