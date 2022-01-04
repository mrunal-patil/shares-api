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
        private readonly GetCycles _getCycles;
        private readonly CreateMatrix _matrixCreator;

        public StockHistoryController(SaveStockHistory saveStockHistory, GetCycles getCycles, CreateMatrix matrixCreator)
        {
            _saveStockHistory = saveStockHistory;
            _getCycles = getCycles;
            _matrixCreator = matrixCreator;
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
        public async Task<IActionResult> GetCycles(DateTime startDate, DateTime endDate, string ticker)
        {
            try
            {
                if (startDate > DateTime.Today || endDate.Date > DateTime.Today)
                    return BadRequest("Start date or end date can not be in the future.");

                var cycles = await _getCycles.Invoke(startDate, endDate, ticker);

                return Ok(cycles);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception);
            }
        }

        [HttpGet("/cycles-matrix")]
        public async Task<IActionResult> GetCyclesMatrix()
        {
            var matrix = await _matrixCreator.Create();

            return Ok(matrix);
        }
    }
}
