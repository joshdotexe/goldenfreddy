using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenFreddy.Models
{
    public class CustomerInvite
    {
        public CustomerInvite()
        {
            Created = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int ToCustomerId { get; set; }
        public Customer ToCustomer { get; set; }
        public int FromCustomerId { get; set; }
        public Customer FromCustomer { get; set; }
        public CustomerInviteStatus Status { get; set; }
        public string Reason { get; set; }

    }
}