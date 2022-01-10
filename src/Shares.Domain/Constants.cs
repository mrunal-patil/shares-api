using System;
using System.Collections.Generic;
using Shares.Domain.Entities;

namespace Shares.Domain
{
    internal static class Constants
    {
        internal static List<string> Tickers = new List<string>
        {
            //"TSLA"
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
            "FB",
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
            "FTK",
            "VTSMX",
            "CSSPX",
            "VUSD.L",
            "BRK-B",
            "MA",
            "AIR",
            "OXY",
            "TWTR",
            "ORCL",
            "AD.AS",
            "BABA",
            "SRG",
            "SAP",
            "INTC",
            "RDS-A",
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
            new PercentageIntervalForStopLoss(new PercentageInterval(7, 10), 5, 10),
            new PercentageIntervalForStopLoss(new PercentageInterval(10, 15), 7, 15),
            new PercentageIntervalForStopLoss(new PercentageInterval(15, 20), 10, 20)
        };
    }
}
