using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class ModelViewCoin : INotifyPropertyChanged
    {
        private Coin selectedCoin;
        private Model model = new Model();
        private ObservableCollection<Coin> coins;

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


        // string coinsJSON;
           public ModelViewCoin()
             {
                 coins = new ObservableCollection<Coin>();
               //  var coin = new Dictionary<string, string>();
                 var tenCoin = model.GetTop10Coins();
                // coin = model.JsonToCoins(a);

                 foreach(var coin_ in tenCoin)
                 {
                     this.coins.Add(coin_);
                
                 }
 
            
        }
           

     




        private BindingList<string> SelectedCoinDetails
        {
            get { return this.SelectedCoinDetails; }
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
