using ShoppingList.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Product.Queries.GetProducts
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Feature { get; set; }
        public bool IsReceived { get; set; }
        public Mesures Mesures { get; set; }
        public int CategoryId { get; set; }
    }
}
