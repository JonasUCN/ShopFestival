using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using WebShop.Models;
using WebShop.ServiceLayer;

namespace WebShop.LogicControllers
{
    /// <summary>
    /// A logic controller for creating and managing sale orders.
    /// </summary>
    public class OrderLogicController
    {
        private DBSaleOrderAccess DBSaleOrderAccess = new();
        private OrderAddress orderAddress = new OrderAddress();

        /// <summary>
        /// Creates a new sale order using the given data and user.
        /// </summary>
        /// <param name="mov">The data to use for creating the sale order.</param>
        /// <param name="user">The user who is creating the sale order.</param>
        /// <returns>The created sale order.</returns>
        public SaleOrder CreateSaleOrder(ModelOrderView mov, IdentityUser user)
        {
            SaleOrder saleOrder = new SaleOrder();
            orderAddress = CreateOrderAddress(mov);
            saleOrder.OrderAddress = orderAddress;
            saleOrder.orderLines = mov.orderLines;
            saleOrder.customer = CustomerLogicController.CreateCustomerFromModelOrderView(mov, user);

            return saleOrder;
        }

        /// <summary>
        /// Adds a sale order to the database.
        /// </summary>
        /// <param name="mov">The sale order to add to the database.</param>
        /// <param name="user">The user who is adding the sale order to the database.</param>
        public bool AddSaleOrderToDB(ModelOrderView mov, IdentityUser user)
        {
            bool status = DBSaleOrderAccess.addSaleOrder(ConvertSaleOrderToJson(CreateSaleOrder(mov, user)),user);
            return status;
        }

        /// <summary>
        /// Converts a sale order to a JSON string.
        /// </summary>
        /// <param name="saleOrder">The sale order to convert to JSON.</param>
        /// <returns>A JSON string representing the given sale order.</returns>
        public string ConvertSaleOrderToJson(SaleOrder saleOrder)
        {
            string jsonString;

            jsonString = JsonConvert.SerializeObject(saleOrder);

            return jsonString;
        }

        /// <summary>
        /// This method creates an OrderAddress object based on the customer's information in a SaleOrder object.
        /// </summary>
        /// <param name="mov">The SaleOrder object that contains the customer's information.</param>
        /// <returns>An OrderAddress object with the customer's street, street number, zipcode, and city information.</returns>
        private OrderAddress CreateOrderAddress(ModelOrderView mov)
        {
            orderAddress.Street = mov.customer.Street;
            orderAddress.streetNo = mov.customer.StreetNo;
            orderAddress.zipcode = mov.customer.ZipCode;
            orderAddress.city = mov.customer.City;
            return orderAddress;
        }
    }
}
