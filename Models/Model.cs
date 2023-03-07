using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Windows;
using Newtonsoft.Json;

namespace Test_Task_New.Models
{       
    class Model
    {
        APIHandler handler = new APIHandler();

        //Get Top 10 coins 
        public List<Coin> GetTop10Coins()
        {
            List<Coin> result = new List<Coin>();
            Task<string> task = handler.GetCoins();
            Coin[] list = JsonHandler.ParseCoins(task.Result);
            for(int i = 0; i < 10; i++) {
                result.Add(list[i]);
            }
            return result;
        }
   
        //Get Detailed info on one coin from json and return Coin with values
        public Coin GetDetailedInfoCoin(string coin)
        { 
            Task<string> task = handler.GetDetailsOneCoin(coin);
            Coin list = JsonHandler.ParseCoin(task.Result.ToString());
            return list;
        }

        //Get Markets And Links
        public Ticker[] GetMarkets(string coin)
        {
            Task<string> task = handler.GetMarketWithLinkJSON(coin);
            MarketArray list = JsonHandler.ParseMarketArray(task.Result.ToString());
            return list.Tickers;
        }

    }
}

