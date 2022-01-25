using System;
using Microsoft.AspNetCore.Mvc;
using Shares.Domain.Usecases;
using System.Threading.Tasks;
using Shares.Domain.Entities;

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
        public async Task<IActionResult> GetAverageOverOneQuarter()
        {
            var matrix = await _averageCalculator.Get(AveragedOver.OneQuarter);

            return Ok(matrix);
        }

        [HttpGet("/two-quarters")]
        public async Task<IActionResult> GetAverageOverTwoQuarters()
        {
            var matrix = await _averageCalculator.Get(AveragedOver.TwoQuarters);

            return Ok(matrix);
        }

        [HttpGet("/yearly")]
        public async Task<IActionResult> GetAverageOverYear()
        {
            var matrix = await _averageCalculator.Get(AveragedOver.Year);

            return Ok(matrix);
        }
    }
}
