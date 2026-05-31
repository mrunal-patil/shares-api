using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shares.Domain.Usecases;

namespace Shares.WebService.Controllers
{
    [ApiController]
    [Route("/")]
    public class DropAnalysisController : ControllerBase
    {
        private readonly GetCycles _getCycles;
        private readonly GetCyclesByPercentageAndDateInterval _getCyclesByPercentageAndDateInterval;
        private readonly StopLossIndicator _stopLossIndicator;

        public DropAnalysisController(GetCycles getCycles, GetCyclesByPercentageAndDateInterval getCyclesByPercentageAndDateInterval, StopLossIndicator stopLossIndicator)
        {
            _getCycles = getCycles;
            _getCyclesByPercentageAndDateInterval = getCyclesByPercentageAndDateInterval;
            _stopLossIndicator = stopLossIndicator;
        }

        

        // Calculate the number of single-drops in stock price over different percentage ranges and date intervals
        [HttpGet("Single-Drops")]
        public async Task<IActionResult> GetCyclesMatrix()
        {
            var matrix = await _getCyclesByPercentageAndDateInterval.Create();

            return Ok(matrix);
        }

        // Calculate the number of cyclic-drops in stock price over different percentage ranges and date intervals
        [HttpGet("Drop-Cycles")]
        public async Task<IActionResult> GetCyclesForIndicatingStopLossMatrix()
        {
            var matrix = await _stopLossIndicator.Invoke();

            return Ok(matrix);
        }
        
        //Calculate stock history in a given range of dates for a particular ticker
        [HttpGet("History-on-demand")]
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
    }
}
