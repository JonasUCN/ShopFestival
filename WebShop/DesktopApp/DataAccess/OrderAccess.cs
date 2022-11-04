﻿using Database_Service.DataAccess;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DesktopApp.DataAccess
{
    public class OrderAccess
    {
        RestClient restClient = new RestClient("https://localhost:5001");

        public async Task<List<SaleOrder>> GetAllSaleOrderAsync()
        {
            var request = new RestRequest("api/SaleOrder/SaleOrder");
            var response = restClient.Get(request);

            List<SaleOrder> saleOrders = JsonConvert.DeserializeObject<List<SaleOrder>>(response.Content);
            return saleOrders;
        }
    }
}
