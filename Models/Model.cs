using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Windows.Controls;
using System;
using System.Windows;

namespace Test_Task_New.Models
{       
    class Model
    {
        APIHandler handler = new APIHandler();


        //Method to Get 10 Names of coins and their prices USING  GetCoins() Method 
     /*   public string GetTopCoins()
        {
            string result = "";

            Task<string> task = handler.GetCoins();
            result = task.Result.ToString();

            var coins = new Dictionary<string, string>();
            coins = JsonToCoins(result);


            return result;
        }
     */
        //Get Top 10 coins 
        public List<Coin> GetTop10Coins()
        {
            List<Coin> result = new List<Coin>();

            Task<string> task;
            task = handler.GetCoins();

            Coin[] list = JsonConvert.DeserializeObject<Coin[]>(task.Result);

            for(int i = 0; i < 10; i++) {
                result.Add(list[i]);
            }
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
        //Get Detailed info on one coin from json and return Coin with values
        public Coin JsonToDetailedInfoCoin(string coin)
        { 
            Task<string> task;
            task = handler.GetDetailsOneCoin(coin);
            string temp = task.Result.ToString();
            //Redo
            temp = temp.Remove(0, temp.IndexOf('{') + 2);
            temp = temp.Remove(0, temp.IndexOf('{'));
            temp = temp.Substring(0, temp.Length - 1);
            Coin list = JsonConvert.DeserializeObject<Coin>(temp);

            return list;
        }
        public MarketArray JsonToMarketLink(string coin)
        {
            Task<string> task;
            task = handler.GetMarketWithLinkJSON(coin);
            string temp = task.Result.ToString();


            MarketArray list = JsonConvert.DeserializeObject<MarketArray>(temp);

            return list;
        }

        /*
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

       */
    }
}

