using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWord.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RightWord.Data.Mappings
{
    public class AgencyMapping : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");
            
            builder.Property(c => c.LegalName)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.BusinessOwner)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.BusinessRegistration)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Address)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.ZipCode)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Country)
                .IsRequired()
                .HasColumnType("varchar(120)");

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(c => c.StudentNationalities)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.HasMany(a => a.Students)
                .WithOne(s => s.Agency)
                .HasForeignKey(s => s.AgencyId);

            builder.ToTable("Agency");
        }
    }
}
