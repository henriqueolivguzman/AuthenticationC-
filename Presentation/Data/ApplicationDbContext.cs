using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Presentation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Engine> Engines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  
            builder.Entity<Aircraft>().ToTable("Aircraft");
            builder.Entity<Engine>().ToTable("Engines");
        }
    }
}