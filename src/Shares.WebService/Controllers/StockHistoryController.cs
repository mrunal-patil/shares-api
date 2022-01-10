using Microsoft.AspNetCore.Mvc;
using Shares.Domain.Usecases;
using Shares.WebService.Dtos.Request;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Shares.WebService.Controllers
{
    [ApiController]
    [Route("api/stock-history")]
    public class StockHistoryController : ControllerBase
    {
        private readonly SaveStockHistory _saveStockHistory;
        private readonly CurrentPerformanceCalculator _currentPerformanceCalculator;

        public StockHistoryController(SaveStockHistory saveStockHistory, CurrentPerformanceCalculator currentPerformanceCalculator)
        {
            _saveStockHistory = saveStockHistory;
            _currentPerformanceCalculator = currentPerformanceCalculator;
        }

        [HttpPost]
        public async Task<IActionResult> Download(StockHistoryDownload stockHistoryDownload)
        {
            try
            {
                if (stockHistoryDownload.StartDate.Date > DateTime.Today || stockHistoryDownload.EndDate.Date > DateTime.Today)
                    return BadRequest("Start date or end date can not be in the future.");

                var stockHistory = await _saveStockHistory.Invoke(stockHistoryDownload.StartDate, stockHistoryDownload.EndDate,
                    stockHistoryDownload.Ticker);

                return Ok(stockHistory);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception);
            }
        }

        [HttpGet]
        [Route("current-performance")]
        public async Task<IActionResult> GetCurrentPerformance()
        {
            var currentPerformance = await _currentPerformanceCalculator.Invoke();
            
            return Ok(currentPerformance);
        }
    }
}
