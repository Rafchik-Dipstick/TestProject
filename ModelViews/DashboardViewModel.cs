using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test_Task_New.Models;
using ZedGraph;

namespace Test_Task_New
{
    public class DashboardViewModel
    {
        //Collections of coins, witch is filled to listbox 
        readonly ObservableCollection<Coin> coins;

        //Instance of model to retrieve coins and markets from API
        Model model = new Model();

        // selectedCoin representing a value of a selectedItem in ListBox
        private Coin selectedCoin;

        //Public constructor for returning coins
        public ObservableCollection<Coin> Coins
        {
            get { return this.coins; }
        }

        //Constructor for this ViewModel. When DashboardView is opened gets top10 coins via Model Method and fills coins Collection.
        public DashboardViewModel()
        {
            coins = new ObservableCollection<Coin>();
            var tenCoin = model.GetTop10Coins();

            foreach (var coin_ in tenCoin)
            {
                this.coins.Add(coin_);
            }
        }
        //Public constructor for returning selected coin and Notify when its changed
        public Coin SelectedCoin
        {
            get { return selectedCoin; }
            set
            {
                selectedCoin = value;
                OnPropertyChanged("SelectedCoin");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
