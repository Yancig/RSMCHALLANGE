using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSMCHALLANGE.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Infrastructure.Configuration
{
    public class TotalofSalesByRegionConfiguration: IEntityTypeConfiguration<vTotalofSalesByRegion>
    {
        void IEntityTypeConfiguration<vTotalofSalesByRegion>.Configure(EntityTypeBuilder<vTotalofSalesByRegion> builder)
        {
            builder
               .HasNoKey()
               .ToView(nameof(vTotalofSalesByRegion),"dbo");

            builder.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(e => e.PercentageOfTotalSalesInRegion).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.PercentajeOfTotalCategorySalesInRegion).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(e => e.TotalSales).HasColumnType("numeric(38, 6)");
        }
    }
}
