using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSMCHALLANGE.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Infrastructure.Configuration
{
    public class SalesReportConfigurationn : IEntityTypeConfiguration<vSalesReport>
    {
        public void Configure(EntityTypeBuilder<vSalesReport> builder)
        {
          
                builder
                    .HasNoKey()
                    .ToView(nameof(vSalesReport), "dbo" );

                builder.Property(e => e.BillingAddress)
                    .IsRequired()
                    .HasMaxLength(60);
                builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
                builder.Property(e => e.OrderDate).HasColumnType("datetime");
                builder.Property(e => e.OrderId).HasColumnName("OrderID");
                builder.Property(e => e.ProductCategory)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.Property(e => e.ProductId).HasColumnName("ProductID");
                builder.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");
                builder.Property(e => e.SalesPersonName)
                    .IsRequired()
                    .HasMaxLength(101);
                builder.Property(e => e.ShippingAddress)
                    .IsRequired()
                    .HasMaxLength(60);
                builder.Property(e => e.TotalPrice).HasColumnType("money");
                builder.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}
