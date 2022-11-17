using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO
{
    public class ModelOrderView
    {
        public Cart cart { get; set; } //Set; is for testing 
        public Customer customer { get; set; } //Set; is for testing in the view & controller
    }
}
