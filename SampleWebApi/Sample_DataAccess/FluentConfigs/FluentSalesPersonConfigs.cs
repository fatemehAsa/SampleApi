using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample_DataAccess.Entities;

namespace Sample_DataAccess.FluentConfigs
{
    public class FluentSalesPersonConfigs:IEntityTypeConfiguration<SalesPerson>
    {
        public void Configure(EntityTypeBuilder<SalesPerson> builder)
        {
            builder
                .HasMany(s => s.Orders)
                .WithOne(s => s.SalesPerson)
                .HasForeignKey(s => s.SalesPersonId);
        }
    }
}
