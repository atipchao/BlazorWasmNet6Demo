using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmNet6Demo.Shared.DTO
{
    public class CartProductResponse
    {
        public int ProductId { get; set; }
        public string  Title { get; set; } = string.Empty;
        public int ProductTypeId { get; set; }
        public string ProductTpye { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; } 
    }
}
