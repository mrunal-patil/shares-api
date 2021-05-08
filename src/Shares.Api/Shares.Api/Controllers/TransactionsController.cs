using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shares.Api.Extensions;
using System.Threading.Tasks;

namespace Shares.Api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.IsValid() == false)
                return BadRequest("File not in correct format. File should be in .xlsx format.");

            var transactions = await file.Parse();

            return Ok(transactions);
        }
    }
}
