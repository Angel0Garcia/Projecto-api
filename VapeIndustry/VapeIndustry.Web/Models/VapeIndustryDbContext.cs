using Microsoft.EntityFrameworkCore;

namespace VapeIndustry.Api.Models
{
    public class VapeIndustryDbContext : DbContext
    {
        public VapeIndustryDbContext(DbContextOptions<VapeIndustryDbContext> options) :base (options) 
        {

        }  

        public DbSet<Product> Products { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasIndex(c => c.Name).IsUnique();
        }

    }
}
