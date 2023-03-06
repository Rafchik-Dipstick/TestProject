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

        public string GetTopCoins()
        {
            string result = "";

            Task<string> task = handler.GetCoins();
            result = task.Result.ToString();

            var coins = new Dictionary<string, string>();
            coins = JsonToCoins(result);


            return result;
        }

    }
}

