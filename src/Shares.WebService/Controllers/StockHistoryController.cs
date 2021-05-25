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

        public StockHistoryController(SaveStockHistory saveStockHistory)
        {
            _saveStockHistory = saveStockHistory;
        }

        [HttpPost]
        public async Task<IActionResult> Download(StockHistoryDownload stockHistoryDownload)
        {
            try
            {
                if (stockHistoryDownload.StartDate.Date > DateTime.Today || stockHistoryDownload.EndDate.Date > DateTime.Today)
                    return BadRequest("Start date or end date can not be in the future.");

                await _saveStockHistory.Invoke(stockHistoryDownload.StartDate, stockHistoryDownload.EndDate,
                    stockHistoryDownload.Ticker);

                return Ok(stockHistoryDownload);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception);
            }
        }
    }
}
