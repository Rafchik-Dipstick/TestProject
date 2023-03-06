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

        }

        private async void DashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new DashboardForm();
            Coin model = new Coin();
            model.JsonToCoin("bitcoin");
           // string a =  Coin.GetDetailsOneCoin("bitcoin");
           // string a = model.Price.ToString(); 
            
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new SearchForm();
        }
    }
}
