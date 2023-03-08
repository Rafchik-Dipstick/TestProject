using Newtonsoft.Json.Linq;
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

namespace Test_Task_New
{
    public class DetailedVIewModel : INotifyPropertyChanged
    {
        // selectedCoin representing a value of a selectedItem in ListBox's
        private Coin selectedCoin;

        //Instance of model to retrieve coins and markets from API
        private Model model = new Model();

        //Collections of coins, witch is filled to listbox 
        readonly ObservableCollection<Coin> coins;

        //A field to contain a coin, that is searched
        private string searchCoin;

        //Public contructor that returns details of selected coin
        private BindingList<string> SelectedCoinDetails
        {
            get { return this.SelectedCoinDetails; }
        }
        //Method that opens default browser with a link of market selected
        private void OpenBrowser(System.Uri value)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = value.ToString(),
                UseShellExecute = true
            });
        }
        //public constructor that returns searched coin and gets detailed info about it
        public string SearchCoin {
            get { return searchCoin; }
            set 
            {
                searchCoin = value;
                GetDetailedInfoSearchedCoin(value);
                OnPropertyChanged("SearchCoin"); }  
            }

        //public constructor that returns selected coin and fills accessible markets to listbox
        public Coin SelectedCoin
        {
            get { return selectedCoin; }
            set
            {
                selectedCoin = value;
                FillMarkets(value.Name);
                OnPropertyChanged("SelectedCoin");
            }
        } 

        //Public construcot that returns coins collection 
        public ObservableCollection<Coin> Coins
        {
            get { return this.coins; }         
        }

        //Method that fills listbox with markets after retrieving detailed info for coin and applies detailed info to textblocks
        public void GetDetailedInfoSearchedCoin(string _temp)
        {
            var coin = model.GetDetailedInfoCoin(_temp);
            FillMarkets(_temp);
            SelectedCoin = coin;
        }

        
        //Public constructor for DetailedView . It gets top 10 coins from api and fills listbox
           public DetailedVIewModel()
             {        
                 coins = new ObservableCollection<Coin>();
                 var tenCoin = model.GetTop10Coins();

                 foreach(var coin_ in tenCoin)
                 {
                     this.coins.Add(coin_);               
                 }    
        }
       
        //Collection of markets and links
        private ObservableCollection<Ticker> markets;

        //Presents selected market
        private Ticker selectedMarket;

        //Public constructor for markets field, that returns markets and links
        public ObservableCollection<Ticker> Markets
        {
            get { return markets; }
        }

        //Public constructor that returns selected Market and link and if changed opens browser with selected market link
        public Ticker SelectedMarket
        {
            get { return selectedMarket; }
            set
            {
                selectedMarket = value;
                OpenBrowser(selectedMarket.TradeUrl);
            }
        }
        //Method for filling list box with market and link to it for selected coin,that is  IN-parameter
        public void FillMarkets(string _coin)
        {
            markets = new ObservableCollection<Ticker>();
            var temp = model.GetMarkets(_coin);
            foreach (var _markets in temp)
            {
                markets.Add(_markets);       
            }
            OnPropertyChanged("Markets");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

       

       
    }
}
