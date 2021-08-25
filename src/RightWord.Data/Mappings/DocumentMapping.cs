using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWord.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RightWord.Data.Mappings
{
    class DocumentMapping : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Image)
                .IsRequired()
                .HasColumnType("varchar(120)");

            builder.ToTable("Document");
        }
    }
}
