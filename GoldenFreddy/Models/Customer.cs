using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenFreddy.Models
{
    public class Customer
    {
        public Customer()
        {
            Created = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Badges { get; set; }
        public ICollection<CustomerInvite> Invites { get; set; }
        public ICollection<CustomerMessage> Messages { get; set; }

    }
}