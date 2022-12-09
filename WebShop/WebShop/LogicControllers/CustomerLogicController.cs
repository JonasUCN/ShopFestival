using WebShop.Models;
using Microsoft.AspNetCore.Identity;
using WebShop.Services;

namespace WebShop.LogicControllers
{
    public class CustomerLogicController
    {

        public static Customer CreateCustomerFromModelOrderView(SaleOrder mov, IdentityUser user)
        {
            Customer c = new Customer();
            c = mov.customer;
            c.Email = user.Email;
            c.userID = user.Id;
            return c;
        }

        public static Customer GetCustomerFromAPIByEmail(string email)
        {
            Customer c = DBCustomerAccess.GetCustomerFromAPIByEmail(email);
            if(c == null)
                c= new Customer();
            return c;
        }

    }
}
