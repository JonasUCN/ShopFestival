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
            mov.customer = new();

            return View(mov);
        }

        [HttpPost]
        public IActionResult OrderView(ModelOrderView _MOV)
        {
            string fname = _MOV.customer.FirstName;
            string lname = _MOV.customer.LastName;
            string city = _MOV.customer.City;
            string street = _MOV.customer.Street;
            string streetNo = _MOV.customer.StreetNo;
            string zipcode = _MOV.customer.ZipCode;
            string email = _MOV.customer.Email;
            string phone = _MOV.customer.Phone;

            Customer c = new Customer { FirstName = fname, LastName = lname, City = city, Street = street, StreetNo = streetNo, Email = email, Phone = phone, ZipCode = zipcode };

            ModelOrderView mov = new ModelOrderView();
            mov.customer = c;

            return View(mov);
        }
    }
}
