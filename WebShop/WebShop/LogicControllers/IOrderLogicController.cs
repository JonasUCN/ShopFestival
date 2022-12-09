using Microsoft.AspNetCore.Identity;
using WebShop.Models;

namespace WebShop.LogicControllers
{
    public interface IOrderLogicController
    {
        SaleOrder CreateSaleOrder(SaleOrder mov, IdentityUser user);
        void AddSaleOrderToDB(SaleOrder mov, IdentityUser user);
        string ConvertSaleOrderToJson(SaleOrder saleOrder);
    }
}
