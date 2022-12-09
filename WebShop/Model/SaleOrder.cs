using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class SaleOrder
    {
        public int OrderNo { get; set; }
        public string Status { get; set; }
        public DateTime? ProcessedDate{ get; set; }
        public DateTime OrderDate { get; set; }
        public Customer customer { get; set; }
        public List<OrderLine> orderLines { get; set; }
 
        public OrderAddress OrderAddress { get; set; }
        public SaleOrder()
        {
            orderLines = new List<OrderLine>();
            OrderDate = DateTime.Now;
            Status = "Active";
            customer = new();
        }
    }
}
