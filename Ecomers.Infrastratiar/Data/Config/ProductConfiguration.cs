using Ecom.Cor.Entites.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastratiar.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.NewPrice).HasColumnType("decimal(18.2)");
            builder.HasData(
            new Product { Id =1, Name = "test2", CatagoryId = 1, Description = "test2", NewPrice = 300 }
             );

        }
    }
}
