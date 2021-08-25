using Microsoft.EntityFrameworkCore;
using RightWord.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightWord.Data.Context
{
    public class RightWordDbContext : DbContext
    {
        public RightWordDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetProperties()
            //        .Where(p => p.ClrType == typeof(string))))
            //    property.Relational().ColumnType = "varcha(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RightWordDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
