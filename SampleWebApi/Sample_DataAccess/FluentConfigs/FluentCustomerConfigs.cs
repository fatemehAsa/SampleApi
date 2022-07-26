using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample_DataAccess.Entities;

namespace Sample_DataAccess.FluentConfigs
{
    public class FluentCustomerConfigs : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder
                .HasMany(c => c.Orders)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}
