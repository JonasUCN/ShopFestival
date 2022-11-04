using Database_Service.DataAccess;
using Database_Service.LogicController;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft;
using Newtonsoft.Json;

namespace Database_Service.Controllers
{
    [Route("api/SaleOrder")]
    [ApiController]
    public class SaleOrderController : Controller
    {
        LogicSaleOrderController _SaleOrderController;

        public SaleOrderController()
        {
            _SaleOrderController = new LogicSaleOrderController();
        }



        // GET: SaleOrderController

        [HttpGet, Route("SaleOrder")]
        public async Task<ActionResult<List<SaleOrder>>> Get()
        {
            List<SaleOrder> saleO = await _SaleOrderController.GetAllSaleOrders();
            ActionResult<List<SaleOrder>> foundReturn;
            if (saleO.Count > 0)
            {
                foundReturn = Ok(saleO);
            }
            else
            {
                foundReturn = NotFound();
            }

            return foundReturn;
        }
    }
}
