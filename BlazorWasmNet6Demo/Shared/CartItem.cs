using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmNet6Demo.Shared
{
    public class CartItem
    {
        //This is justy for the Client project
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
