using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample_DataAccess.Entities;

namespace Sample_DataAccess.FluentConfigs
{
    public class FluentOrderConfigs : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasMany(o => o.OrderItems)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
