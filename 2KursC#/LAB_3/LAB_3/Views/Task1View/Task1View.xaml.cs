using System.Windows;
using System.Windows.Controls;

namespace LAB_3.Views.Task1View
{
    public partial class Task1View : UserControl
    {
        public Task1View()
        {
            InitializeComponent();
        }

        private void OnHello(object sender, RoutedEventArgs e)
        {
            StatusLabel.Content = "Привіт";
        }

        private void OnBye(object sender, RoutedEventArgs e)
        {
            StatusLabel.Content = "До побачення";
        }
    }
}
