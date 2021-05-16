using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shares.Api.Extensions;
using Shares.Domain.Uescases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly ProfitCalculator _profitCalculator;

        public TransactionsController(ProfitCalculator profitCalculator)
        {
            _profitCalculator = profitCalculator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.IsValid() == false)
                return BadRequest("File not in correct format. File should be in .xlsx format.");

            var transactions = await file.Parse();

            var shares = transactions.ToDomainEntities();

            var sharesToReturn = new List<Dtos.Share>();
            foreach (var share in shares)
            {
                var profitPerTransaction = _profitCalculator.Get(share);

                var shareDto = share.ToDto(profitPerTransaction);

                sharesToReturn.Add(shareDto);
            }

            return Ok(sharesToReturn);
        }
    }
}