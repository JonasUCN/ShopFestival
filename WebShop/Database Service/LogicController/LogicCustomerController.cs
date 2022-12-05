using Database_Service.DataAccess;
using ModelLayer;

namespace Database_Service.LogicController
{
    public class LogicCustomerController
    {

        private DBAccessCustomer accessCustomer = new();

        public Customer GetCustomerFromEmail(string email)
        {
            Customer c = accessCustomer.GetCustomerByEmail(email);
            return c;
        }

    }
}
