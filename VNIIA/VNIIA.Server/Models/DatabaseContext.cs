using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace VNIIA.Server.Models
{
	public class DatabaseContext : DbContext
	{
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentPosition> DocumentPostions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=VniiaDb;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        //https://docs.microsoft.com/ru-ru/ef/core/modeling/relationships?tabs=fluent-api%2Cdata-annotations-simple-key%2Csimple-key
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Создаём связь один ко многим между Document и DocumentPosition. (1 документ и много позиций документа)
            modelBuilder.Entity<DocumentPosition>()
                .HasOne(p => p.Document)
                .WithMany(b => b.DocumentPositions)
                .HasForeignKey(k=>k.DocumentId);
        }
    }
}
