using Cleo.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace Cleo.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
