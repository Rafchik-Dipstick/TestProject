using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_New.Models
{
    public class APIHandler
    {
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
        public async Task<string> GetCoins()
        {
            string result;
            const string API_PATH = @"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false";

            using (var client = new HttpClient())
            {
                Task<string> responce = client.GetStringAsync(API_PATH);

                result = responce.Result;
            }
            return result;

        }
        public async Task<string> GetDetailsOneCoin(string coin)
        {
            string result;
            string API_PATH = @"https://api.coingecko.com/api/v3/simple/price?ids=" + coin + "&vs_currencies=USD&include_market_cap" +
                "=true&include_24hr_vol=true&include_24hr_change=true&include_last_updated_at=true";

            using (var client = new HttpClient())
            {
                Task<string> responce = client.GetStringAsync(API_PATH);
                result = responce.Result;
            }
            return result;
            
        }
        public async Task<string> GetMarketWithLinkJSON(string coin)
        {
            string result;
            string API_PATH = @"https://api.coingecko.com/api/v3/coins/bitcoin?tickers=true&market_data=t
                                rue&community_data=true&developer_data=false&sparkline=false";

            using (var client = new HttpClient())
            {
                Task<string> responce = client.GetStringAsync(API_PATH);
                result = responce.Result;          
            }
            return result;

        }

    }

}
