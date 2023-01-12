using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);
            
            builder.Property(c => c.Id)
                .HasColumnName("IdProduct")
                .UseIdentityColumn();

            builder.Property(c => c.Name)
                .HasColumnName("Nome");

            builder.Property(c => c.Price)
                .HasColumnName("Preco");

            builder.Property(c => c.CodErp)
                .HasColumnName("CodErp");

            builder.HasMany(x=> x.Purchases)
                .WithOne(p => p.Product)
                .HasForeignKey(c => c.ProductId);


        }
    }
}
