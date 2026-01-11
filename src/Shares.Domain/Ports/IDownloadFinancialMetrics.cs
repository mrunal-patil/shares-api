using System.Collections.Generic;
using System.Threading.Tasks;
using Shares.Domain.Entities;

namespace Shares.Domain.Ports;

public interface IDownloadFinancialMetrics
{
 Task<IReadOnlyCollection<FinancialMetrics>> GetAll();
}