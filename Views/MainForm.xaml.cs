using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Test_Task_New.Models;
using Test_Task_New.ModelViews;

namespace Test_Task_New.Views
{
    /// <summary>
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();
            CC.Content = new DashboardForm();
            DashboardBtn.IsEnabled = false;
            DetailedInfo.IsEnabled = true;
        }

        private void DashboardBtn_Click(object sender, RoutedEventArgs e)
        {

            CC.Content = new DashboardForm();
            DashboardBtn.IsEnabled = false;
            DetailedInfo.IsEnabled = true;

            // Coin model = new Coin();
            //  model.JsonToCoin("bitcoin");
            // string a =  Coin.GetDetailsOneCoin("bitcoin");
            // string a = model.Price.ToString(); 

        }

       

        private void DetailedBtn_Click(object sender, RoutedEventArgs e)
        { 
            CC.Content = new SearchForm();
            DashboardBtn.IsEnabled = true;
            DetailedInfo.IsEnabled = false;
        }

      
    }
}
