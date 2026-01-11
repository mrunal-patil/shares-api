using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shares.Domain.Ports;

namespace Shares.WebService.Controllers;

[ApiController]
[Route("api/financial-metrics")]
public class FinancialMetricsController: ControllerBase
{
    private readonly IDownloadFinancialMetrics _financialMetricsDownloader;

    public FinancialMetricsController(IDownloadFinancialMetrics financialMetricsDownloader)
    {
        _financialMetricsDownloader = financialMetricsDownloader;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetFinancialMetrics()
    {
        var matrix = await _financialMetricsDownloader.GetAll();

        return Ok(matrix);
    }
}