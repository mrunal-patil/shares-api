using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shares.Domain.Usecases;

namespace Shares.WebService.Controllers
{
    [ApiController]
    [Route("/")]
    public class DropAnalysisController : ControllerBase
    {
        private readonly GetCyclesByPercentageAndDateInterval _getCyclesByPercentageAndDateInterval;
        private readonly StopLossIndicator _stopLossIndicator;

        public DropAnalysisController(GetCycles getCycles, GetCyclesByPercentageAndDateInterval getCyclesByPercentageAndDateInterval, StopLossIndicator stopLossIndicator)
        {
            _getCyclesByPercentageAndDateInterval = getCyclesByPercentageAndDateInterval;
            _stopLossIndicator = stopLossIndicator;
        }

        // Calculate the number of single-drops in stock price over different percentage ranges and date intervals.
        // For example, how many times in a given time interval (between 01-01-2016 and 31-12-2020) that
        // a share dropped between 3% and 5% and then rose above 0% 
        [HttpGet("Single-Drops")]
        public async Task<IActionResult> GetCyclesMatrix()
        {
            var matrix = await _getCyclesByPercentageAndDateInterval.Create();
            return Ok(matrix);
        }

        // Calculate the number of cyclic-drops in stock price over different percentage ranges and date intervals.
        // For example, how many times in a given time interval (between 01-01-2016 and 31-12-2020) that
        // a share dropped below 7%, then rose above 4% and then again dropped below 7%
        [HttpGet("Drop-Cycles")]
        public async Task<IActionResult> GetCyclesForIndicatingStopLossMatrix()
        {
            var matrix = await _stopLossIndicator.Invoke();
            return Ok(matrix);
        }
    }
}
