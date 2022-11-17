using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;
using ModelLayer;
using Newtonsoft.Json;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        
        public IActionResult OrderView()
        {
            ModelOrderView mov = new ModelOrderView();
            mov.orderLines = JsonConvert.DeserializeObject<List<OrderLine>>(HttpContext.Session.GetString("OrderLines"));
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
            DBSaleOrderAccess.addSaleOrder();

            return View(mov);
        }
    }
}
