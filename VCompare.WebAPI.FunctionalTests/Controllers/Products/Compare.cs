using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VCompare.Application.Products.Queries;
using VCompare.WebAPI.FunctionalTests.Common;
using Xunit;

namespace VCompare.WebAPI.FunctionalTests.Controllers.Products
{
    public class Compare : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Compare(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsAListOfProductViewModels()
        {
            var response = await _client.GetAsync("/api/products/compare?averageConsumption=3500");
            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<IEnumerable<ProductViewModel>>(response);

            Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(result);
            Assert.NotEmpty(result);
        }
    }
}