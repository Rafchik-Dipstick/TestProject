using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection.Emit;

namespace Test_Task_New.Models
{
    class Model
    {
        public string Price;
        public string Name;
        public string MarketCap;
        public string hVol;
        public string hChange;
        public string lUpdatedAt;




        //search currency
        public async Task<string> SearchCoin(string coin)
        {
            string coins;
            string result;
            coins =  await GetCoins();
          
            if(coins.IndexOf(coin) != -1)
            {
                var responce = await GetDetailsOneCoin(coin);
                result = responce.ToString();
            }
            else
            {
                result = "NULL";
            }
            return result;
        }

        //get Connection Status // Done // 
        public async Task<string> CheckConnection()
        {
            const string API_PATH = @"https://api.coingecko.com/api/v3/ping";
            string result;
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(API_PATH);
                if (response != "{ }")
                {
                    result = "OK";
                    return result;
                }
                else return result = "NULL";
            }
        }
        //get to 10 Currencies // Getting All For Now // Review Required // 
        public async Task<string> GetCoins()
        {
            string result;
            const string API_PATH = @"https://api.coingecko.com/api/v3/coins/list";

            using (var client = new HttpClient())
            {
                var responce = await client.GetStringAsync(API_PATH);
                result = responce.ToString(); 
            }
            return result;
           
        }


        //get detailed info about 1 currency
        public async Task<string> GetDetailsOneCoin(string coin)
        {
            string result;
            string API_PATH = @"https://api.coingecko.com/api/v3/simple/price?ids="+ coin +"&vs_curr" +
                "encies=usd&include_market_cap=true&include_2" +
                "4hr_vol=true&include_24hr_change=true&include_last_updated_at=true";

            using (var client = new HttpClient())
            {
                var responce = await client.GetStringAsync(API_PATH);
                if (responce != "{ }")
                {
                    //Some Text Adjustments, Sorry for the mess :)

                    // EXAMPLE for understaning (OUTPUT from API)
                    /*{
                             "bitcoin": {
                                  "usd": 22364,
                                  "usd_market_cap": 431652373594.5801,
                                  "usd_24h_vol": 17929343610.844704,
                                  "usd_24h_change": -0.22370915235796515,
                                  "last_updated_at": 1677941629
                                         }
                       }
                     */
                    //Geting Price by substring from 0 to index of marketcap
                    Price = responce.Substring(0, responce.IndexOf("usd_market_cap"));
                    //Replacing all letter with "", leaving only digits
                    Price = Regex.Replace(Price, "[^0-9.+-]", "");
                    //Getting MarketCap by substing from index of market_cap to index of 24h_vol minus length of "usd_24h_vol"
                    MarketCap = responce.Substring(responce.IndexOf("usd_market_cap"), responce.IndexOf("usd_24h_vol") - "usd_24h_vol".Length );
                    //Deleting everything exept value for marketcap
                    MarketCap = MarketCap.Substring(0, MarketCap.LastIndexOf(",\""));
                    //replacing all letterwith "", leaving only digits
                    MarketCap = Regex.Replace(MarketCap, "[^0-9.+-]", "");
                    //doing same for 24H_VOL
                    hVol = responce.Substring(responce.IndexOf("usd_24h_vol" ), responce.IndexOf("usd_24h_change") - "usd_24h_change".Length);
                    hVol = hVol.Substring(0, hVol.LastIndexOf("e\""));
                    hVol = hVol.Substring(2, hVol.Length - 2);
                    hVol = Regex.Replace(hVol, "[^0-9.+-]", "");
                    hVol = hVol.Substring(0, hVol.Length - 2);
                    //doing same for 24h_Change
                    hChange = responce.Substring(responce.IndexOf("usd_24h_change"));
                    hChange = hChange.Substring(0, hChange.LastIndexOf(",\""));
                    hChange = Regex.Replace(hChange, "[^0-9.+-]", "");
                    hChange = hChange.Substring(2, hChange.Length - 2);
                    //doing same for Last Updated At
                    lUpdatedAt = responce.Substring(responce.IndexOf("last_updated_at"));
                    lUpdatedAt = Regex.Replace(lUpdatedAt, "[^0-9.+-]", "");
                    result = "OK";
                    return result;
                }
                else { result = "NULL";
                       return result;
                }
               
            }
        
        }
        
    }
}

