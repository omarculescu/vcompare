using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using VCompare.Application.Products.Queries;
using VCompare.Application.Tests.Infrastructure;
using VCompare.Persistence;
using Xunit;
using System.Linq;

namespace VCompare.Application.Tests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetComparisonResultQueryHandlerTests
    {
        private const string PRODUCT_1_NAME = "Basic electricity tariff";
        private const string PRODUCT_2_NAME = "Packaged tariff";
        private readonly VCompareDbContext _context;

        public GetComparisonResultQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task CompareTest()
        {
            var handler = new GetComparisonResultQueryHandler(_context);
            var result = await handler.Handle(new GetComparisonResultQuery { AverageConsumption = 3500 }, CancellationToken.None);
            result.ShouldBeAssignableTo<IEnumerable<ProductViewModel>>();
            result.Count().ShouldBe(2);
            result.First().Price.ShouldBeLessThanOrEqualTo(result.Last().Price);
        }

        [Fact]
        public async Task ShowProduct2OnTopForAverageConsumption3500()
        {
            var handler = new GetComparisonResultQueryHandler(_context);
            var query = new GetComparisonResultQuery { AverageConsumption = 3500 };
            var result = await handler.Handle(query, CancellationToken.None);
            result.First().Name.ShouldBe(PRODUCT_2_NAME);
        }

        [Fact]
        public async Task ShowProduct2OnTopForAverageConsumption4500()
        {
            var handler = new GetComparisonResultQueryHandler(_context);
            var query = new GetComparisonResultQuery { AverageConsumption = 4500 };
            var result = await handler.Handle(query, CancellationToken.None);
            result.First().Name.ShouldBe(PRODUCT_2_NAME);
        }

        [Fact]
        public async Task ShowProduct1OnTopForAverageConsumption6000()
        {
            var handler = new GetComparisonResultQueryHandler(_context);
            var query = new GetComparisonResultQuery { AverageConsumption = 6000 };
            var result = await handler.Handle(query, CancellationToken.None);
            result.First().Name.ShouldBe(PRODUCT_1_NAME);
        }
    }
}