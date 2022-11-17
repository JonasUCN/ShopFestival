﻿using System;
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

        public DateTime ProcessedDate{ get; set; }

        public DateTime OrderDate { get; set; }

        public Customer customer { get; set; }

        public SaleOrder()
        {
            OrderDate = DateTime.Now;
            Status = "Active";
        }
    }
}
