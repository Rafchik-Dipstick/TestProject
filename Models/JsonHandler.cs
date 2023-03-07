using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Test_Task_New.Models
{
    public static class JsonHandler
    {

        internal static Coin ParseCoin(string _json)
        {
            //Redo
            _json = _json.Remove(0, _json.IndexOf('{') + 2);
            _json = _json.Remove(0, _json.IndexOf('{'));
            _json = _json.Substring(0, _json.Length - 1);
            return JsonConvert.DeserializeObject<Coin>(_json);
        }

        internal static Coin[] ParseCoins(string _json)
        {
            return JsonConvert.DeserializeObject<Coin[]>(_json);
        }

        internal static MarketArray ParseMarketArray(string _json)
        {
           return JsonConvert.DeserializeObject<MarketArray>(_json);
        }
    }
}
