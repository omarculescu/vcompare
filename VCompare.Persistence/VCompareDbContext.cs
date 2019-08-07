using Microsoft.EntityFrameworkCore;
using VCompare.Application.Interfaces;
using VCompare.Domain.Entities;

namespace VCompare.Persistence
{
    public class VCompareDbContext : DbContext, IVCompareDbContext
    {
        public VCompareDbContext(DbContextOptions<VCompareDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<PriceCalculationModel> PriceCalculationModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VCompareDbContext).Assembly);
        }
    }
}