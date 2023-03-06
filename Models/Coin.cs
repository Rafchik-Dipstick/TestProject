using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_New.Models
{
    public class Coin
    {
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

        //Creating Alias For JSON

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
        APIHandler handler = new APIHandler();



        public BindingList<string> GetInfoToBL(string coin)
        {
            var result = new BindingList<string>();
            _ = handler.GetDetailsOneCoin(coin);

            result.Add(Price);
            result.Add(Name);
            result.Add(MarketCap);
            result.Add(hVol);
            result.Add(hChange);
            result.Add(lUpdatedAt);

            return result;
        }

        
        

        //Get coins one by one from string of all coins from API
        public Dictionary<string, string> JsonToCoins(string responce)
        {
            var coin = new Dictionary<string, string>();
            string price;
            string name;

            Coin[] list = JsonConvert.DeserializeObject<Coin[]>(responce);

            for (int i = 0; i < 9; i++)
            {
                name = list[i].Name;
                price = list[i].Price;
                coin.Add(name, price);
            }

            return coin;
        }


        //Get Detailed info on one coin from json 
        public void JsonToCoin(string coin)
        {
            Task<string> task;
            task = handler.GetDetailsOneCoin(coin);
            string temp = task.Result.ToString();
            temp = temp.Remove(0, temp.IndexOf('{') + 2);
            temp = temp.Remove(0, temp.IndexOf('{'));
            temp = temp.Substring(0, temp.Length - 1);
            Coin list = JsonConvert.DeserializeObject<Coin>(temp);


            Price_ = list.Price;
            MarketCap_ = list.MarketCap;
            hVol_ = list.hVol;
            hChange_ = list.hChange;
            lUpdatedAt_ = list.lUpdatedAt_;
        }


    }
}
