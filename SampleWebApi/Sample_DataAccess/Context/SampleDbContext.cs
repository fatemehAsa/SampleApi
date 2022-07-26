using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample_DataAccess.Entities;
using Sample_DataAccess.FluentConfigs;

namespace Sample_DataAccess.Context
{
    public class SampleDbContext:DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext>options):base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentCustomerConfigs());
            modelBuilder.ApplyConfiguration(new FluentSalesPersonConfigs());
            modelBuilder.ApplyConfiguration(new FluentOrderConfigs());
            modelBuilder.ApplyConfiguration(new FluentOrderItemConfigs());


        }
    }

   
}
