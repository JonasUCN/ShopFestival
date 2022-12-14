using Microsoft.AspNetCore.Identity;
﻿using RestSharp;


namespace WebShop.ServiceLayer
{
    /// <summary>
    /// This class provides methods for accessing sale order information from a database through an API.
    /// </summary>
    public class DBSaleOrderAccess
    {
        /// <summary>
        /// This method is used to add a sale order to the database through an API.
        /// </summary>
        /// <param name="saleOrderJson">A JSON string representation of the sale order to add.</param>
        /// <param name="user">The user who is adding the sale order.</param>
        /// <returns>True if the sale order was added successfully, false otherwise.</returns>
        public static bool addSaleOrder(string saleOrderJson, IdentityUser user)
        {
            string url = "https://localhost:5001/api/SaleOrder/AddOrder/" + saleOrderJson;
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ServiceToken.GetTokenLoggedInUser(user)}");
            var response = client.Post(request);
            if(response.Content == "true")
            {
               return true;
            }
            return false;
        }
    }
}
