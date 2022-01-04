using Microsoft.AspNetCore.Mvc;
using Shares.Domain.Usecases;
using System.Threading.Tasks;

namespace Shares.WebService.Controllers
{
    [ApiController]
    [Route("api/stock-average")]
    public class StockAverageController : ControllerBase
    {
        private readonly AverageCalculator _averageCalculator;

        public StockAverageController(AverageCalculator averageCalculator)
        {
            _averageCalculator = averageCalculator;
        }

        [HttpGet("/one-quarter")]
        public async Task<IActionResult> GetAverage()
        {
            var matrix = await _averageCalculator.Get();

            return Ok(matrix);
        }
    }
}
