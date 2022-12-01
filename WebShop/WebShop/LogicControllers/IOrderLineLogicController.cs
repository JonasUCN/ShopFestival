using ModelLayer;

namespace WebShop.LogicControllers
{
    public interface IOrderLineLogicController
    {
        string CreateNewOrderlines(OrderLine orderLine);

        string AddToExcistingOrderLines(string JsonOrderLines, OrderLine orderLine);

        string CheckExistingOrderLine(HttpContext http, OrderLine orderLine);

    }
}
