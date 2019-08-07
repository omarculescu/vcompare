using System.Collections.Generic;
using MediatR;

namespace VCompare.Application.Products.Queries
{
    public class GetComparisonResultQuery : IRequest<IEnumerable<ProductViewModel>>
    {
        public int AverageConsumption { get; set; }
    }
}