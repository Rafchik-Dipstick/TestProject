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
        //String With Basic Api link
        string API_PATH = "https://api.coingecko.com/api/v3/";

        //Method to check if API is online
        public  Task<string> CheckConnection()
        {
            string RequestUrl = API_PATH + "ping";
            using (var client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(RequestUrl);
                if (response.Status.ToString() == "RanToCompletion")
                {
                    return response;
                }
                else
                {
                    throw new Exception("Bad Request");
                }
            }
        }
        //Method to get top 100 coins from API and return as Task<string>
        public async Task<string> GetCoins()
        {
              string result;
              string RequestUrl = API_PATH + "coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false";

            using (var client = new HttpClient())
            {
                Task<string> responce = client.GetStringAsync(RequestUrl);
                if (responce.Status.ToString() == "RanToCompletion" || responce.Status.ToString() ==  "WaitingForActivation")
                {
                    result = responce.Result;
                    return result;
                }
                else
                {
                    throw new Exception("Bad Request");
                }
            }
        }
        //Method to get detailed info about single coin, that is given within IN-parameter, and returned detailed info as Task<string>
        public async Task<string> GetDetailsOneCoin(string coin)
        {
            string result;
            string RequestUrl = API_PATH + "simple/price?ids=" + coin + "&vs_currencies=USD&include_market_cap" +
                "=true&include_24hr_vol=true&include_24hr_change=true&include_last_updated_at=true";

            using (var client = new HttpClient())
            {
                Task<string> responce = client.GetStringAsync(RequestUrl);
                if (responce.Status.ToString() == "RanToCompletion" || responce.Status.ToString() == "WaitingForActivation")
                {
                    result = responce.Result;
                    return result;
                }
                else
                {
                    throw new Exception("Bad Request");
                }
            }
        }
        //Method to get Markets and Links to them for selected coin from IN-parameter, returned value is Task<string>
        public async Task<string> GetMarketWithLinkJSON(string coin)
        {
            string result;
            string RequestUrl = API_PATH + @"coins/"+coin+"?tickers=true&market_data=true &community_data=true&developer_data=false&sparkline=false";

            using (var client = new HttpClient())
            {
                Task<string> responce =  client.GetStringAsync(RequestUrl);
                if (responce.Status.ToString() == "RanToCompletion" || responce.Status.ToString() == "WaitingForActivation")
                {
                    result = responce.Result;
                    return result;
                }
                else
                {
                    throw new Exception("Bad Request");
                }
            }
        }

    }

}
