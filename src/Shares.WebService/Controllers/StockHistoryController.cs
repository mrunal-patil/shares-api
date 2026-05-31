using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shares.Domain.Usecases;
using System.Threading.Tasks;
using Shares.Domain.Entities;
using Shares.WebService.Dtos.Request;

namespace Shares.WebService.Controllers
{
    [ApiController]
    public class StockHistoryController(AverageCalculator averageCalculator, SaveStockHistory saveStockHistory) : ControllerBase
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
        
        // Report closing value of a specific stock on a specific date (check this by running it)
        // Convert this from Post to Get
        [HttpPost("/")]
        public async Task<IActionResult> Download(StockHistoryDownload stockHistoryDownload)
        {
            try
            {
                if (stockHistoryDownload.StartDate.Date > DateTime.Today || stockHistoryDownload.EndDate.Date > DateTime.Today)
                    return BadRequest("Start date or end date can not be in the future.");

                var stockHistory = await saveStockHistory.Invoke(stockHistoryDownload.StartDate, stockHistoryDownload.EndDate,
                    stockHistoryDownload.Ticker);

                return Ok(stockHistory);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception);
            }
        }
    }
}
