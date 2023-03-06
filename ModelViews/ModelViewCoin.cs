using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test_Task_New.Models;

namespace Test_Task_New
{
    public class ModelViewCoin : INotifyPropertyChanged
    {
        private Coin selectedCoin;
        private Model model;
        


        private Coin SelectedCoin
        { 
            get { return this.selectedCoin; } 

            set { this.selectedCoin = value; OnPropertyChanged("SelectedCoin"); } 

        }

        private string GetDetailedInfoCoin (Coin coin)
        {
            
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
