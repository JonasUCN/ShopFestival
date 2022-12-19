using WebShop.Models;
using Microsoft.AspNetCore.Identity;
using WebShop.ServiceLayer;

namespace WebShop.LogicControllers
{
    /// <summary>
    /// This class provides logic for managing customer data.
    /// </summary>
    public class CustomerLogicController
    {
        /// <summary>
        /// Creates a new Customer object from the provided SaleOrder and IdentityUser.
        /// </summary>
        /// <param name="mov">The SaleOrder object to use as the basis for the new Customer.</param>
        /// <param name="user">The IdentityUser object to use to populate the Customer's email and userID properties.</param>
        /// <returns>A new Customer object created from the provided SaleOrder and IdentityUser.</returns>
        public static Customer CreateCustomerFromModelOrderView(SaleOrder mov, IdentityUser user)
        {
            Customer c = new Customer();
            c = mov.customer;
            c.Email = user.Email;
            c.userID = user.Id;
            return c;
        }

        /// <summary>
        /// Retrieves a Customer from the database by email.
        /// </summary>
        /// <param name="email">The email address to use to lookup the Customer.</param>
        /// <returns>A Customer object matching the provided email address, or a new Customer object if no matching Customer was found.</returns>
        public static Customer GetCustomerFromAPIByEmail(string email)
        {
            Customer c = DBCustomerAccess.GetCustomerFromAPIByEmail(email);
            if(c == null)
                c= new Customer();
            return c;
        }

    }
}
