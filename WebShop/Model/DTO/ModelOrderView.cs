using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO
{
    public class ModelOrderView
    {
        public List<OrderLine> orderLines { get; set; } //Set; is for testing 
        public Customer customer { get; set; } //Set; is for testing in the view & controller

        public ModelOrderView()
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
