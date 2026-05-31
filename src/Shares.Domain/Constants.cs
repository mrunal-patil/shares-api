using System;
using System.Collections.Generic;
using Shares.Domain.Entities;

namespace Shares.Domain
{
    public static class Constants
    {
        /// <summary>
        /// List of tickers used for daily performance tracking and fundamental analysis 
        /// including Earnings Per Share (EPS) and Book Value Per Share (BVPS) ratios.
        /// </summary>
        public static readonly List<string> CurrentPerformanceTickers =
        [
            "4GLD.DE",
            "SGBS.MI",
            "XAD6.DE",
            "EXXT.DE",
            "XLKS.MI",
            "QQQ3.MI",
            "SOXL.MI",
            "BRK-B",
            "NVDA",
            "AVGO",
            "ASML",
            "LRCX",
            "NXPI",
            "INTC",
            "AMD",
            "TSM",
            "MU",
            "QCOM",
            "HY9H.F",
            "AAPL",
            "GOOGL",
            "MSFT",
            "AMZN",
            "META",
            "CRM",
            "ADBE",
            "NFLX",
            "ISRG",
            "TER",
            "TSLA",
            "PLTR",
            "ARM",
            "SNPS",
            "IBM",
            "LLY",
            "NVO",
            "KOG.OL",
            "RHM.DE",
            "SDV1.F",
            "HO.PA",
            "FTK.DE",
            "NKE",
            "ETSY",
            "STNE",
            "DIS",
            "ABNB",
            "KLAC",
            "MA",
            "AIR",
            "OXY",
            "ORCL",
            "AD.AS",
            "BABA",
            "SAP",
            "SHEL",
            "BP",
            "UNH",
            "PYPL",
            "VTSMX",
            "^DJI",
            "%5EIXIC",
            "CSSPX.MI",
            "VUSD.L",
            "^BSESN",
            "^NSEI",
            "SPY5.L"
        ];

        /// <summary>
        /// List of tickers processed for quarterly stock average calculations.
        /// </summary>
        internal static readonly List<string> StockAverageTickers =
        [
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
            "NVO",
            "LLY",
            "KOG.OL",
            "RHM.DE",
            "SDV1.F",
            "HO.PA",
            "UNH",
            "SNPS",
            "000660.KS",
            "SOXL.MI"

        ];
        
        /// <summary>
        /// Tickers that should be excluded from financial metric calculations (EPS/BVPS).
        /// This typically includes indices, ETFs, or commodities where these ratios are not applicable.
        /// </summary>
        public static readonly List<string> IgnoredFinancialMetricsTickers =
        [
            "4GLD.DE",
            "SGBS.MI",
            "XAD6.DE",
            "EXXT.DE",
            "XLKS.MI",
            "QQQ3.MI",
            "SOXL.MI",
            "HY9H.F",
            "KOG.OL",
            "RHM.DE",
            "SDV1.F",
            "HO.PA",
            "FTK.DE",
            "STNE",
            "AD.AS",
            "VTSMX",
            "^DJI",
            "%5EIXIC",
            "CSSPX.MI",
            "VUSD.L",
            "^BSESN",
            "^NSEI",
            "SPY5.L"
            
        ];

        /// <summary>
        /// Defines the percentage ranges used to categorize market drops (e.g., 3-5%, 5-7%).
        /// </summary>
        internal static readonly List<PercentageInterval> PercentageIntervals =
        [
            new(3, 5),
            new(5, 7),
            new(7, 10),
            new(10, 15),
            new(15, 20),
            new(20, 30),
            new(30, 40),
            new(40, 100)
        ];

        /// <summary>
        /// Defined year intervals used for historical performance comparison and data grouping.
        /// </summary>
        internal static readonly List<YearInterval> YearIntervals =
        [
            new(new DateTime(2024, 01, 01), new DateTime(2030, 12, 31)), // Current Period
            new(new DateTime(2021, 01, 01), new DateTime(2023, 12, 31)),
            new(new DateTime(2016, 01, 01), new DateTime(2020, 12, 31)),
            new(new DateTime(2011, 01, 01), new DateTime(2015, 12, 31))
        ];

        /// <summary>
        /// Defines cyclic drop thresholds and corresponding stop-loss percentages.
        /// </summary>
        internal static readonly List<PercentageIntervalForStopLoss> PercentageIntervalsForStopLoss =
        [
            new(7, 4),
            new(10, 6),
            new(15, 10),
            new(20, 14),
            new(25, 18),
            new(30, 22),
            new(40, 30)
        ];
    }
}
