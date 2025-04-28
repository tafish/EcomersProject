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
    public class CatogreConfigretion : IEntityTypeConfiguration<Catagory>
    {
        public void Configure(EntityTypeBuilder<Catagory> builder)
        {
         
            builder.Property( c => c.Name).IsRequired().HasMaxLength(30);
            builder.Property( c => c.Id).IsRequired();
            builder.HasData(
               new Catagory { Id = 1, Name = "test", Description = "test", }
                );
        }
    }
}
