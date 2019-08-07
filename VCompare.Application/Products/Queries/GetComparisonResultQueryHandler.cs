using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VCompare.Application.Interfaces;

namespace VCompare.Application.Products.Queries
{
    public class GetComparisonResultQueryHandler : IRequestHandler<GetComparisonResultQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IVCompareDbContext _context;

        public GetComparisonResultQueryHandler(IVCompareDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ProductViewModel>> Handle(GetComparisonResultQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return _context.Products.Select(p => new ProductViewModel
                {
                    Name = p.Name,
                    Price = p.PriceCalculationModel.CalculatePriceForAverageConsumption(request.AverageConsumption)
                })
                .ToList()
                .OrderBy(p => p.Price)
                .AsEnumerable();
            }, cancellationToken);
        }
    }
}