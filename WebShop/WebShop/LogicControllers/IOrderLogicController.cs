using WebShop.Models;

namespace WebShop.LogicControllers
{
    public interface IOrderLogicController
    {
        SaleOrder CreateSaleOrder(SaleOrder mov);

        void AddSaleOrderToDB(SaleOrder mov);

        string ConvertSaleOrderToJson(SaleOrder saleOrder);
    }
}
