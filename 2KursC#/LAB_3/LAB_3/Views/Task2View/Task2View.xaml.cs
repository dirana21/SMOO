using System.Windows;
using System.Windows.Controls;

namespace LAB_3.Views.Task2View
{
    public partial class Task2View : UserControl
    {
        public Task2View()
        {
            InitializeComponent();
        }

        private void OnHide(object sender, RoutedEventArgs e) => TheText.Visibility = Visibility.Collapsed;
        private void OnShow(object sender, RoutedEventArgs e) => TheText.Visibility = Visibility.Visible;
    }
}
