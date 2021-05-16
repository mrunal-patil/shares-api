using System.Collections.Generic;
using ShareEntity = Shares.Domain.Entities.Share;

namespace Shares.Api.Dtos
{
    public class Share
    {
        public string Isin { get; set; }
        public string Name { get; set; }
        public List<Profit> ProfitPerTransaction { get; set; } = new List<Profit>();
    }
}
