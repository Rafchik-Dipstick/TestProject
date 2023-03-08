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

            SwitchLanguage("ua");
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
        }



        private void DetailedBtn_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new SearchForm();
            DashboardBtn.IsEnabled = true;
            DetailedInfo.IsEnabled = false;
        }


        private void EnglishLang(object sender, RoutedEventArgs e)
        {
            SwitchLanguage("en");
        }
        private void UkrainianLang (object sender, RoutedEventArgs e)
        {
            SwitchLanguage("ua");

        }
        private void SwitchLanguage(string language)
        {
  
            this.Resources.MergedDictionaries.Add(Models.Localization.SwitchLanguage(language));  
        }
        private void lightmode_click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "White";
            Properties.Settings.Default.Save();
        }
        private void darkmode_click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Dark";
            Properties.Settings.Default.Save();
        }

      
    }
}
