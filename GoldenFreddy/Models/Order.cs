using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenFreddy.Models
{
    public class Order
    {
        public Order()
        {
            Created = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime Created { get; private set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal OrderAmount { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}