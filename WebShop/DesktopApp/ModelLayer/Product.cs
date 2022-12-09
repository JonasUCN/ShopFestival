using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ModelLayer
{
    public class Product
    {
        public int id { get; set; }
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ProductDesc { get; set; }

        public string Brand { get; set; }
        public string Title { get; set; }
    }
}