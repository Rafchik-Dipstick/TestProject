using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_New.Models
{
    public class Coin : INotifyPropertyChanged
    {

        //Current class impelements a Coin Model, witch can contain some or all
        //of implemented parameters, also added JsonProperty aliases, to prop deserialize from json
        //
        //Creating Alias For JSON
        [JsonProperty("current_price")]
        public string Price { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("market_cap")]
        public string MarketCap { get; set; }
        [JsonProperty("high_24h")]
        public string hVol { get; set; }
        [JsonProperty("price_change_24h")]
        public string hChange { get; set; }
        [JsonProperty("price_change_percentage_24h")]
        public string lUpdatedAt { get; set; }



        [JsonProperty("usd")]
        private string Price_ { set { Price = value; } }
        [JsonProperty("usd_market_cap")]
        private string MarketCap_ { set { MarketCap = value; } }
        [JsonProperty("usd_24h_vol")]
        private string hVol_ { set { hVol = value; } }
        [JsonProperty("usd_24h_change")]
        private string hChange_ { set { hChange = value; } }
        [JsonProperty("last_updated_at")]
        private string lUpdatedAt_ { set { lUpdatedAt = value; } }

        

    }
}
