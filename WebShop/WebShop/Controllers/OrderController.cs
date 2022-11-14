using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;
using ModelLayer;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        
        public IActionResult OrderView()
        {
            ModelOrderView mov = new ModelOrderView();
            Product product = new Product() { Brand = "Addias", Price = 10, ProductDesc = "Festivals Sko", Stock = 50, Title = "Festivals sko", id = 3 };
            OrderLine orderLine = new OrderLine { Product = product, Quantity = 21 };
            Cart cart = new Cart();
            cart.addOrderLine(orderLine);
            mov.cart = cart;

            return View(mov);
        }

        [HttpPost]
        public IActionResult OrderView(ModelOrderView _MOV)
        {
            

            return View();
        }
    }
}
