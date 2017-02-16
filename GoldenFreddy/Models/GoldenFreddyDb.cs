﻿using System;
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
        public DbSet<CustomerInvite> CustomerInvites { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<CustomerInvite>()
            //            .HasRequired(e => e.FromCustomer)
            //            .WithMany(c => c.Invites)
            //            .HasForeignKey(e => e.FromCustomerId)
            //            .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CustomerInvite>()
            //            .HasRequired(e => e.ToCustomer)
            //            .WithMany(c => c.Invites)
            //            .HasForeignKey(e => e.ToCustomerId)
            //            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Invites)
                .WithRequired(i => i.FromCustomer)
                .HasForeignKey(i => i.FromCustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Invites)
                .WithRequired(i => i.ToCustomer)
                .HasForeignKey(i => i.ToCustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Messages)
                .WithRequired(m => m.FromCustomer)
                .HasForeignKey(m => m.FromCustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Messages)
                .WithRequired(m => m.ToCustomer)
                .HasForeignKey(m => m.ToCustomerId)
                .WillCascadeOnDelete(false);

        }
    }
}