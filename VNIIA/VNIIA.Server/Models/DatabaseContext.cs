using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace VNIIA.Server.Models
{
    public class DatabaseContext : DbContext
    {
		public DatabaseContext()
		{

		}

		public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
		{

		}
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentPosition> DocumentPositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Создаём связь один ко многим между Document и DocumentPosition. (1 документ и много позиций документа)
            modelBuilder.Entity<DocumentPosition>()
                .HasOne(p => p.Document)
                .WithMany(b => b.Positions)
                .HasForeignKey(k => k.DocumentId);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is Document doc)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            {
                                doc.Amount = DocumentPositions.Where(c=>c.DocumentId == doc.Number).Select(c=>c.Sum).Sum();
                            }
                            break;
                    }
                }
            }
        }
    }
}
