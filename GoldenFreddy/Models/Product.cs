using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenFreddy.Models
{
    public class Product
    {
        public Product()
        {
            Created = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime Created { get; private set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ProductCategory Category { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}