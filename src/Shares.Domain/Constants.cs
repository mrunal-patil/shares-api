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
            "3GOL.MI",
            "3SIL.MI",
            "EXXT.DE",
            "XLKS.MI",
            "QQQ3.MI",
            "SOXL.L",
            "QSL5.DE",
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
            "SPCX",
            "PLTR",
            "ARM",
            "SNPS",
            "IBM",
            "PANW",
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
            "MXWS.L",
            "XDEW.MI",
            "EMIM.L",
            "INDA",
            "GLD",
            "GC=F",
            "SLV",
            "SI=F"
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
            "GLD",
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
            "SOXL.L",
            "QSL5.DE",
            "PANW",
            "SPCX",
            "3GOL.MI",
            "3SIL.MI",
            "GC=F",
            "SLV",
            "SI=F",
            "MXWS.L",
            "XDEW.MI",
            "EMIM.L",
            "INDA"
        ];
        
        /// <summary>
        /// Tickers that should be excluded from Financial Metrics calculations (EPS/BVPS).
        /// This typically includes indices, ETFs, or commodities where these ratios are not applicable.
        /// </summary>
        public static readonly List<string> IgnoredFinancialMetricsTickers =
        [
            "4GLD.DE",
            "SGBS.MI",
            "XAD6.DE",
            "3GOL.MI",
            "3SIL.MI",
            "EXXT.DE",
            "XLKS.MI",
            "QQQ3.MI",
            "SOXL.L",
            "QSL5.DE",
            "BRK-B",
            "HY9H.F",
            "SPCX",
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
            "MXWS.L",
            "XDEW.MI",
            "EMIM.L",
            "INDA",
            "GLD",
            "GC=F",
            "SLV",
            "SI=F"     
            
        ];

        /// <summary>
        /// This section is a heavy request for the Data Source, therefore it limits the number of data points.
        /// Currently, it gives the output for 63 tickers for 6 data ranges;
        /// if the number of tickers or the number of data ranges increase, then the program (=Data Source) returns a Zero.
        /// Therefore, comment specific tickers which are less important if the result starts producing zeroes.
        /// To comment or Uncomment: ctr+/         ; or: alt+Enter, and then select either Comment or Uncomment.
        ///
        /// Verify the ticker in the first column of the output excel file while using the data.
        /// Run the File with different configurations of tickers in case information for new tickers is needed. 
        /// </summary>
        public static readonly List<string> DropTickers =
        [
            "4GLD.DE",
            "SGBS.MI",
            "XAD6.DE",
            "3GOL.MI",
            "3SIL.MI",
            "EXXT.DE",
            "XLKS.MI",
            "QQQ3.MI",
            "SOXL.L",
            "QSL5.DE",
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
            "SPCX",
            "PLTR",
            "ARM",
            "SNPS",
            "IBM",
            "PANW",
            "LLY",
            "NVO",
            "KOG.OL",
            "RHM.DE",
            "SDV1.F",
            "HO.PA",
            "FTK.DE",
            "NKE",
            "ETSY",
            //"STNE",
            //"DIS",
            //"ABNB",
            //"KLAC",
            //"MA",
            //"AIR",
            //"OXY",
            //"ORCL",
            //"AD.AS",
            //"BABA",
            //"SAP",
            //"SHEL",
            //"BP",
            //"UNH",
            //"PYPL",
            "VTSMX",
            "^DJI",
            "%5EIXIC",
            "CSSPX.MI",
            "VUSD.L",
            "^BSESN",
            "^NSEI",
            "MXWS.L",
            "XDEW.MI",
            "EMIM.L",
            "INDA",
            "GLD",
            "GC=F",
            "SLV",
            "SI=F"
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
            new(new DateTime(2011, 01, 01), new DateTime(2015, 12, 31)),
            new(new DateTime(2006, 01, 01), new DateTime(2010, 12, 31)),
            new(new DateTime(1996, 01, 01), new DateTime(2005, 12, 31))
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
