using Database_Service.DataAccess;
using Database_Service.Model;

namespace Database_Service.LogicController
{
    /// <summary>
    /// Provides methods for interacting with a database of customers.
    /// </summary>
    public class LogicCustomerController
    {
        private DBAccessCustomer accessCustomer = new();

        /// <summary>
        /// Retrieves a customer from the database with the specified email address.
        /// </summary>
        /// <param name="email">The email address of the customer to retrieve.</param>
        /// <returns>The customer with the specified email address, or null if no such customer exists.</returns>
        public Customer GetCustomerFromEmail(string email)
        {
            Customer c = accessCustomer.GetCustomerByEmail(email);
            return c;
        }
    }
}
