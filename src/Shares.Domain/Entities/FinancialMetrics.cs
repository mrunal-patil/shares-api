namespace Shares.Domain.Entities;

public class FinancialMetrics
{
    public string Ticker { get; set; }
    public decimal EarningPerShareTTM { get; set; }
    public decimal PriceToEarningsTTM { get; set; }
}