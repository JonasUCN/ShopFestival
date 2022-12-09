using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ModelLayer
{
    public class SaleOrder
    {
        public int OrderNo { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderLine> orderLines { get; set; } //Set; is for testing 
        public Customer customer { get; set; } //Set; is for testing in the view & controller

        public SaleOrder()
        {
            customer = new Customer();
        }
        public double GetTotalPrice()
        {
            double sum = 0;
            foreach (var item in orderLines)
            {
                sum += (double)item.SubTotal;
            }
            return sum;
        }
    }
}