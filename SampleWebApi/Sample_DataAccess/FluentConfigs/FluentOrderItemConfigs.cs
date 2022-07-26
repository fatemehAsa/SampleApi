using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample_DataAccess.Entities;

namespace Sample_DataAccess.FluentConfigs
{
    public class FluentOrderItemConfigs : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {

            builder
                .HasOne(i => i.Product)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(i => i.ProductId);
        }
    }
}
