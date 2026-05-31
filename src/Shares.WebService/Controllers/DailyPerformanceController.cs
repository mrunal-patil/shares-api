using Microsoft.AspNetCore.Mvc;
using Shares.Domain.Usecases;
using Shares.WebService.Dtos.Request;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Shares.WebService.Controllers
{
    [ApiController]
    [Route("/")]
    public class DailyPerformanceController : ControllerBase
    {
        private readonly CurrentPerformanceCalculator _currentPerformanceCalculator;

        public DailyPerformanceController(CurrentPerformanceCalculator currentPerformanceCalculator)
        {
            _currentPerformanceCalculator = currentPerformanceCalculator;
        }

        [HttpGet]
        [Route("Daily-Performance")]
        public async Task<IActionResult> GetCurrentPerformance()
        {
            var currentPerformance = await _currentPerformanceCalculator.Invoke();
            
            return Ok(currentPerformance);
        }
    }
}
