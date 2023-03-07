using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_Task_New.Models;
//4using Test_Task_New.ModelViews;

namespace Test_Task_New
{
    public class DetailedVIewModel : INotifyPropertyChanged
    { 
        private Coin selectedCoin;
        private Model model = new Model();
        readonly ObservableCollection<Coin> coins;
       
      //  private Ticker[] marketlink;
        private string searchCoin;
        private Ticker selectedMarket;

        public Ticker SelectedMarket { get { return selectedMarket; }
            set
            {
                selectedMarket = value;
                OpenBrowser(selectedMarket.TradeUrl);
                
            }
        }

        private void OpenBrowser(System.Uri value)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = value.ToString(),
                UseShellExecute = true
            });
        }

        public string SearchCoin {
            get { return searchCoin; }
            set 
            {
                searchCoin = value;
                GetDetailedInfoSearchedCoin(value);
                OnPropertyChanged("SearchCoin"); }  
            }

        public Coin SelectedCoin
        {
            get { return selectedCoin; }
            set
            {
                selectedCoin = value;
                OnPropertyChanged("SelectedCoin");
            }
        }

        public ObservableCollection<Coin> Coins
        {
            get { return this.coins; }         
        }

        
        public void GetDetailedInfoSearchedCoin(string _temp)
        {
            var coin = model.JsonToDetailedInfoCoin(_temp);
            SelectedCoin = coin;
        }

        

        // string coinsJSON;
           public DetailedVIewModel()
             {        
                  coins = new ObservableCollection<Coin>();
                  var tenCoin = model.GetTop10Coins();

                 foreach(var coin_ in tenCoin)
                 {
                     this.coins.Add(coin_);               
                 }
                   FillMarkets();
        }

        private ObservableCollection<Ticker> markets;      
        public ObservableCollection<Ticker> Markets
        {
            get { return markets; }
            set
            {
                markets = value;
                OnPropertyChanged("MarketLink");
            }
        }
        public ObservableCollection<Ticker> FillMarkets()
        {
            markets = new ObservableCollection<Ticker>();
            var temp = model.JsonToMarketLink("bitcoin");

            foreach (var _markets in temp)
            {
                markets.Add(_markets);
            }
            return markets;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private BindingList<string> SelectedCoinDetails
        {
            get { return this.SelectedCoinDetails; }          
        }

       
    }
}
