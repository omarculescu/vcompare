using Microsoft.EntityFrameworkCore;
using VCompare.Domain.Entities;

namespace VCompare.Application.Interfaces
{
    public interface IVCompareDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}