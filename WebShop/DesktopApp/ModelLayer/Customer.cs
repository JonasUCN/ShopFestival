using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ModelLayer
{
    /// <summary>
    /// The `Customer` class contains various properties related to a customer.
    /// </summary>
    public class Customer
    {
        // The customer's first name
        public string FirstName { get; set; }

        // The customer's last name
        public string LastName { get; set; }

        // The customer's zip code
        public string ZipCode { get; set; }

        // The customer's city
        public string City { get; set; }

        // The customer's street
        public string Street { get; set; }

        // The customer's street number
        public string StreetNo { get; set; }

        // The customer's phone number
        public string Phone { get; set; }

        // The customer's email address
        public string Email { get; set; }
    }
}