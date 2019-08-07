using System;
using Microsoft.EntityFrameworkCore;
using VCompare.Domain.Entities;
using VCompare.Persistence;

namespace VCompare.Application.Tests.Infrastructure
{
    public class VCompareDbContextFactory
    {
        public static VCompareDbContext Create()
        {
            var options = new DbContextOptionsBuilder<VCompareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new VCompareDbContext(options);

            context.Database.EnsureCreated();

            context.Products.AddRange(new []{
                new Product {
                    Id = 1,
                    Name = "Basic electricity tariff"
                },
                new Product {
                    Id = 2,
                    Name = "Packaged tariff"
                }
            });
            context.SaveChanges();

            context.PriceCalculationModels.AddRange(new [] {
                new PriceCalculationModel {
                    ProductId = 1,
                    Amount = 5,
                    Base = 12,
                    PricePerKWH = 0.22m
                },
                new PriceCalculationModel {
                    ProductId = 2,
                    Amount = 800,
                    Base = 1,
                    Limit = 4000,
                    PricePerKWH = 0.30m
                }
            });
            context.SaveChanges();

            return context;
        }

        public static void Destroy(VCompareDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}