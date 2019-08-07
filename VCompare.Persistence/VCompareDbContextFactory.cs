using Microsoft.EntityFrameworkCore;
using VCompare.Persistence.Infrastructure;

namespace VCompare.Persistence
{
    public class VCompareDbContextFactory : DesignTimeDbContextFactoryBase<VCompareDbContext>
    {
        protected override VCompareDbContext CreateNewInstance(DbContextOptions<VCompareDbContext> options)
        {
            return new VCompareDbContext(options);
        }
    }
}