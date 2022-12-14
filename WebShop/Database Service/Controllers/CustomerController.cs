using Database_Service.LogicController;
using Microsoft.AspNetCore.Mvc;
using Database_Service.Model;

namespace Database_Service.Controllers
{
    /// <summary>
    /// This is the CustomerController class
    /// It provides a set of API endpoints for managing customers
    /// </summary>
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private LogicCustomerController logicCustomer = new();

        /// <summary>
        /// Gets a customer with the specified email address
        /// </summary>
        /// <param name="email">The email address of the customer</param>
        /// <returns>The customer with the specified email address</returns>
        [HttpGet, Route("Customers/{email}")]
        public async Task<Customer> GetCustomerByEmail(string email)
        {
            Customer c = logicCustomer.GetCustomerFromEmail(email);
            return c;
        }
    }
}
