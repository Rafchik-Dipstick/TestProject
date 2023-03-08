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
        readonly ObservableCollection<Coin> coins;
        Model model = new Model();
        private Coin selectedCoin;
        public ObservableCollection<Coin> Coins
        {
            get { return this.coins; }
        }

        public DashboardViewModel()
        {
            coins = new ObservableCollection<Coin>();
            var tenCoin = model.GetTop10Coins();

            foreach (var coin_ in tenCoin)
            {
                this.coins.Add(coin_);
            }
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
