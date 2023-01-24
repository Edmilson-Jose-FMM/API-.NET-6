﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("compra");

            builder.HasKey(x => x.Id);
            
            builder.Property(c => c.Id)
                .HasColumnName("idcompra")
                .UseIdentityColumn();

            builder.Property(c => c.ProductId)
                .HasColumnName("idproduto");

            builder.Property(x => x.PersonId)
                .HasColumnName("idpessoa");

            builder.Property(c => c.Date)
                .HasColumnName("datacompra");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Purchases);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Purchases);
         }
    }
}
