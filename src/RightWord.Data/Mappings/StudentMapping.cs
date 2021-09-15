using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWord.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RightWord.Data.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p => p.Id);
            
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Surname)
                .IsRequired()
                .HasColumnType("varchar(200)");
            
            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(120)");

            builder.Property(c => c.Passport)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Country)
                .IsRequired()
                .HasColumnType("varchar(120)");

            builder.Property(c => c.NativeLanguage)
                .IsRequired()
                .HasColumnType("varchar(120)");

            builder.Property(c => c.PartnerName)
                .HasColumnType("varchar(300)");

            builder.HasMany(s => s.Documents)
                .WithOne(d => d.Student)
                .HasForeignKey(d => d.StudentId);

            builder.ToTable("Student");
        }
    }
}
