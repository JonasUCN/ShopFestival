using Database_Service.LogicController;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace Database_Service.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private LogicCustomerController logicCustomer = new();

        [HttpGet, Route("Customers/{email}")]
        public async Task<Customer> GetCustomerByEmail(string email)
        {
            Customer c = logicCustomer.GetCustomerFromEmail(email);
            return c;
        }
    }
}
