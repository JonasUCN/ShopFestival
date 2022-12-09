using Microsoft.AspNetCore.Identity;
﻿using RestSharp;
using WebShop.ServiceLayer;
using WebShop.Services;

namespace WebShop.ServiceLayer
{
    public class DBSaleOrderAccess : IDBSaleOrderAccess
    {

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

}}
