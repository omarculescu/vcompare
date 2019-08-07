using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VCompare.Application.Products.Queries;

namespace VCompare.WebAPI.Controllers
{
    public class ProductsController : BaseController
    {
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Compare([FromQuery] int averageConsumption)
        {
            return Ok(await Mediator.Send(new GetComparisonResultQuery { AverageConsumption = averageConsumption }));
        }
    }
}