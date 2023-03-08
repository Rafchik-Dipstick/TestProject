
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Test_Task_New.Views
{
    /// <summary>
    /// Логика взаимодействия для DashboardForm.xaml
    /// </summary>
    public partial class DashboardForm : UserControl
    {
        public DashboardForm()
        {
            InitializeComponent();
            
            this.DataContext = new DashboardViewModel();
        }

        private void GetDetaulsBtn_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = ListBoxTop10.GetBindingExpression(ListBox.SelectedItemProperty);
            binding.UpdateSource();
        }
    }
}
