using System;
using Microsoft.AspNetCore.Mvc;
using Shares.Domain.Usecases;
using System.Threading.Tasks;
using Shares.Domain.Entities;

namespace Shares.WebService.Controllers
{
    [ApiController]
    public class StockHistoryController(AverageCalculator averageCalculator) : ControllerBase
    {
        [HttpGet("Averaged-Over-One-Quarter")]
        public async Task<IActionResult> GetAverageOverOneQuarter()
        {
            var matrix = await averageCalculator.Get(AveragedOver.OneQuarter);

            return Ok(matrix);
        }

        [HttpGet("Averaged-Over-Two-Quarters")]
        public async Task<IActionResult> GetAverageOverTwoQuarters()
        {
            var matrix = await averageCalculator.Get(AveragedOver.TwoQuarters);

            return Ok(matrix);
        }

        [HttpGet("Averaged-Over-Four-Quarters")]
        public async Task<IActionResult> GetAverageOverYear()
        {
            var matrix = await averageCalculator.Get(AveragedOver.Year);

            return Ok(matrix);
        }
    }
}
