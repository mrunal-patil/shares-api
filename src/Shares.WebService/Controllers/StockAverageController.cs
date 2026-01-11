using System;
using Microsoft.AspNetCore.Mvc;
using Shares.Domain.Usecases;
using System.Threading.Tasks;
using Shares.Domain.Entities;

namespace Shares.WebService.Controllers
{
    [ApiController]
    [Route("api/stock-average")]
    public class StockAverageController(AverageCalculator averageCalculator) : ControllerBase
    {
        [HttpGet("/one-quarter")]
        public async Task<IActionResult> GetAverageOverOneQuarter()
        {
            var matrix = await averageCalculator.Get(AveragedOver.OneQuarter);

            return Ok(matrix);
        }

        [HttpGet("/two-quarters")]
        public async Task<IActionResult> GetAverageOverTwoQuarters()
        {
            var matrix = await averageCalculator.Get(AveragedOver.TwoQuarters);

            return Ok(matrix);
        }

        [HttpGet("/yearly")]
        public async Task<IActionResult> GetAverageOverYear()
        {
            var matrix = await averageCalculator.Get(AveragedOver.Year);

            return Ok(matrix);
        }
    }
}
