using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shares.Api.Extensions;
using System.Threading.Tasks;
using Shares.Domain.Uescases;

namespace Shares.Api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly GetShareHistory _getShareHistory;

        public TransactionsController(GetShareHistory getShareHistory)
        {
            _getShareHistory = getShareHistory;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.IsValid() == false)
                return BadRequest("File not in correct format. File should be in .xlsx format.");

            var transactions = await file.Parse();

            var entities = transactions.ToDomainEntities();

            return Ok(entities);
        }
    }
}
