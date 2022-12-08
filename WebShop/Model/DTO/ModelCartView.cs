using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO
{
    public class ModelCartView
    {
        public List<OrderLine> OrderLines { get; set; }
        public bool Loggedin { get; set; }

        public double CalcSubTotal()
        {
            double sum = 0;

            foreach (OrderLine line in OrderLines)
            {
                sum += line.CalcSubTotal();
            }

            return sum;
        }
    }
}
