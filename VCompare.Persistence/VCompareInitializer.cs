using System.Linq;
using VCompare.Domain.Entities;

namespace VCompare.Persistence
{
    public class VCompareInitializer
    {
        public static void Initialize(VCompareDbContext context)
        {
            var initializer = new VCompareInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(VCompareDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return; // Db has been seeded already
            }
            SeedProducts(context);
            SeedPriceCalculationModels(context);
        }

        public void SeedProducts(VCompareDbContext context)
        {
            var products = new[] {
                new Product {
                    Id = 1,
                    Name = "Basic electricity tariff"
                },
                new Product {
                    Id = 2,
                    Name = "Packaged tariff"
                }
            };
            context.Products.AddRange(products);

            context.SaveChanges();
        }

        public void SeedPriceCalculationModels(VCompareDbContext context)
        {
            var priceCalculationModels = new[] {
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
            };
            context.PriceCalculationModels.AddRange(priceCalculationModels);

            context.SaveChanges();
        }
    }
}