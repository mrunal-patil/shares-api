using System;
using System.Collections.Generic;
using Shares.Domain.Entities;

namespace Shares.Domain
{
    internal static class Constants
    {
        internal static List<string> CurrentPerformanceTickers = new List<string>
        {
            "EXXT.DE",
            "XLKS.MI",
            "QQQ3.MI",
            "BRK-B",
            "CSSPX.MI",
            "VUSD.L",
            "%5EIXIC",
            "^DJI",
            "VTSMX",
            "^BSESN",
            "^NSEI",
            "4GLD.DE",
            "SGBS.MI",
            "SPY5.L",
            "XAD6.DE",
            "ASML",
            "NVDA",
            "GOOGL",
            "MSFT",
            "AAPL",
            "AVGO",
            "INTC",
            "AMD",
            "TSM",
            "MU",
            "QCOM",
            "LRCX",
            "NXPI",
            "KLAC",
            "TER",
            "ADBE",
            "META",
            "NFLX",
            "ISRG",
            "CRM",
            "AMZN",
            "NKE",
            "PYPL",
            "TSLA",
            "ETSY",
            "AMS.SW",
            "PLTR",
            "DIS",
            "ABNB",
            "STNE",
            "FTK.DE",
            "MA",
            "AIR",
            "OXY",
            "ORCL",
            "AD.AS",
            "BABA",
            "SRG",
            "SAP",
            "SHEL",
            "BP",
            "IBM",
            "ARM",
            "UNH",
            "LLY",
            "NVO"
        };

        internal static List<string> StockAverageTickers = new List<string>
        {
            "EXXT.DE",
            "XLKS.MI",
            "%5EIXIC",
            "ASML",
            "NVDA",
            "AMD",
            "PYPL",
            "GOOGL",
            "MSFT",
            "LRCX",
            "AAPL",
            "TER",
            "TSM",
            "ADBE",
            "ISRG",
            "META",
            "AVGO",
            "QCOM",
            "NKE",
            "NFLX",
            "CRM",
            "KLAC",
            "MU",
            "AMZN",
            "TSLA",
            "ETSY",
            "PLTR",
            "STNE",
            "DIS",
            "ABNB",
            "FTK.DE",
            "BRK-B",
            "VTSMX",
            "CSSPX.MI",
            "VUSD.L",
            "MA",
            "AIR",
            "OXY",
            "NXPI",
            "ORCL",
            "AD.AS",
            "BABA",
            "SRG",
            "SAP",
            "INTC",
            "SHEL",
            "BP",
            "AMS.SW",
            "SPY5.L",
            "4GLD.DE",
            "SGBS.MI",
            "^DJI",
            "^BSESN",
            "^NSEI",
            "IBM",
            "ARM",
            "QQQ3.MI",
            "XAD6.DE",
            "UNH",
            "LLY",
            "NVO"
        };

        internal static List<PercentageInterval> PercentageIntervals = new List<PercentageInterval>
        {
            new PercentageInterval(3, 5),
            new PercentageInterval(5, 7),
            new PercentageInterval(7, 10),
            new PercentageInterval(10, 15),
            new PercentageInterval(15, 20),
            new PercentageInterval(20, 30),
            new PercentageInterval(30, 40),
            new PercentageInterval(40, 100)
        };

        internal static List<YearInterval> YearIntervals = new List<YearInterval>
        {
            new YearInterval(new DateTime(2021, 01, 01), DateTime.Today),
            new YearInterval(new DateTime(2016, 01, 01), new DateTime(2020, 12, 31)),
            new YearInterval(new DateTime(2011, 01, 01), new DateTime(2015, 12, 31))
        };

        internal static List<PercentageIntervalForStopLoss> PercentageIntervalsForStopLoss = new List<PercentageIntervalForStopLoss>
        {
            new PercentageIntervalForStopLoss(7, 4),
            new PercentageIntervalForStopLoss(10, 6),
            new PercentageIntervalForStopLoss(15, 10),
            new PercentageIntervalForStopLoss(20, 14),
            new PercentageIntervalForStopLoss(25, 18),
            new PercentageIntervalForStopLoss(30, 22),
            new PercentageIntervalForStopLoss(40, 30)
        };
    }
}
