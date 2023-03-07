using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_Task_New.Views
{
    /// <summary>
    /// Логика взаимодействия для SearchForm.xaml
    /// </summary>
    public partial class SearchForm : UserControl
    {
        public SearchForm()
        {
            InitializeComponent();
            this.DataContext = new DetailedVIewModel();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = Searchtxt.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();

        }

        private void BtnOpenBrowser_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = listBoxMarkets.GetBindingExpression(ListBox.SelectedItemProperty);
            binding.UpdateSource();
        }

        private void listBoxTop10Coins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
