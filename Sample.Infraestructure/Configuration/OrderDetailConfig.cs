using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infraestructure.Configuration
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasKey(x => new { x.OrderId, x.ProductId });

            builder.Property(x => x.UnitPrice)
                .HasPrecision(18, 2);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Discount);
        }
    }
}
