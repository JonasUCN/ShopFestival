using WebShop.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.LogicControllers
{
    /// <summary>
    /// Provides methods for managing order lines in a web shop application.
    /// </summary>
    public class OrderLineLogicController : IOrderLineLogicController
    {
        private List<OrderLine> OrderLines;

        /// <summary>
        /// Initializes a new instance of the OrderLineLogicController class.
        /// </summary>
        /// <param name="inConfiguration">The application configuration.</param>
        public OrderLineLogicController(IConfiguration inConfiguration)
        {
        }

        /// <summary>
        /// Creates a new OrderLine object.
        /// </summary>
        /// <param name="orderLine">The OrderLine to be created.</param>
        /// <returns>A JSON string representing the created OrderLine.</returns>
        public string CreateNewOrderlines(OrderLine orderLine)
        {
            OrderLines = new List<OrderLine>();
            OrderLines.Add(orderLine);
            string JsonOrderLines = JsonConvert.SerializeObject(OrderLines);
            return JsonOrderLines;
        }

        /// <summary>
        /// Adds an order line to an existing list of order lines.
        /// </summary>
        /// <param name="JsonOrderLines">A JSON string representing the existing list of order lines.</param>
        /// <param name="orderLine">The order line to add to the existing list.</param>
        /// <returns>A JSON string representing the updated list of order lines.</returns>
        public string AddToExcistingOrderLines(string JsonOrderLines, OrderLine orderLine)
        {
            OrderLines = JsonConvert.DeserializeObject<List<OrderLine>>(JsonOrderLines);
            bool QuantityWasUpdatede = false;
            foreach (var item in OrderLines)
            {
                if (orderLine.Product.id == item.Product.id)
                {
                    item.Quantity += orderLine.Quantity;
                    QuantityWasUpdatede = true;

                }
            }

            if (QuantityWasUpdatede == false)
            {
                OrderLines.Add(orderLine);
            }

            string JsonOrderLinesToReturn = JsonConvert.SerializeObject(OrderLines);
            return JsonOrderLinesToReturn;
        }

        /// <summary>
        /// Checks for an existing order line in the current session. If it doesn't exist,
        /// it creates a new list of order lines with the given order line. Otherwise,
        /// it adds the given order line to the existing list of order lines.
        /// </summary>
        /// <param name="http">The current HTTP context.</param>
        /// <param name="orderLine">The order line to add to the list of order lines.</param>
        /// <returns>A JSON string representing the updated list of order lines.</returns>
        public string CheckExistingOrderLine(HttpContext http, OrderLine orderLine)
        {
            string json;
            if (http.Session.GetString("OrderLines") == null)
            {
                json = CreateNewOrderlines(orderLine);
            }
            else
            {
                string JsonOrderlines = http.Session.GetString("OrderLines");
                json = AddToExcistingOrderLines(JsonOrderlines, orderLine);

            }
            http.Session.SetString("OrderLines", json);
            return json;
        }
    }
}