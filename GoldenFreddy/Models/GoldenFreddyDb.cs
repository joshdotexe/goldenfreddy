using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GoldenFreddy.Models
{
    public class GoldenFreddyDb : DbContext
    {
        public DbSet<CustomerMessage> CustomerMessages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BusinessLocation> BusinessLocations { get; set; }
        public DbSet<Business> Businesses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<GoldenFreddy.Models.CustomerInvite> CustomerInvites { get; set; }

        public System.Data.Entity.DbSet<GoldenFreddy.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<GoldenFreddy.Models.Product> Products { get; set; }
    }
}