using ModelLayer.DTO;
using ModelLayer;

namespace WebShop.LogicControllers
{
    public interface IOrderLogicController
    {
        SaleOrder CreateSaleOrder(ModelOrderView mov);

        void AddSaleOrderToDB(ModelOrderView mov);

        string ConvertSaleOrderToJson(SaleOrder saleOrder);
    }
}
