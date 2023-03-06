using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_New.Models
{
    public partial class MarketArray
    {
        [JsonProperty("tickers")]
        public Ticker[] Tickers { get; set; }
    }

    public partial class Ticker
    {
        [JsonProperty("market")]
        public Market Market { get; set; }

        [JsonProperty("trade_url")]
        public Uri TradeUrl { get; set; }
    }

    public partial class Market
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

