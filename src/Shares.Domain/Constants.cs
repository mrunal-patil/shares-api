using System;
using System.Collections.Generic;
using Shares.Domain.Entities;

namespace Shares.Domain
{
    internal static class Constants
    {
        internal static List<string> Tickers = new List<string>
        {
            //"TSLA",
            //"AAPL"
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
            "CSSPX",
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
            "BP"
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
            new YearInterval(new DateTime(2020, 01, 01), DateTime.Today),
            new YearInterval(new DateTime(2015, 01, 01), new DateTime(2019, 12, 31)),
            new YearInterval(new DateTime(2010, 01, 01), new DateTime(2014, 12, 31))
        };

        internal static List<PercentageIntervalForStopLoss> PercentageIntervalsForStopLoss = new List<PercentageIntervalForStopLoss>
        {
            new PercentageIntervalForStopLoss(7, 5),
            new PercentageIntervalForStopLoss(10, 7),
            new PercentageIntervalForStopLoss(15, 10),
            new PercentageIntervalForStopLoss(20, 15),
            new PercentageIntervalForStopLoss(25, 20),
            new PercentageIntervalForStopLoss(30, 25),
            new PercentageIntervalForStopLoss(40, 30)
        };
    }
}
