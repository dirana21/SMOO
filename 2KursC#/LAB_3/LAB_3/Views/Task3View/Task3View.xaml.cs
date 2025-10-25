using System.Windows;
using System.Windows.Controls;

namespace LAB_3.Views.Task3View
{
    public partial class Task3View : UserControl
    {
        public Task3View() => InitializeComponent();

        private void OnHide(object sender, RoutedEventArgs e) => InputBox.Visibility = Visibility.Collapsed;
        private void OnShow(object sender, RoutedEventArgs e) => InputBox.Visibility = Visibility.Visible;
        private void OnClear(object sender, RoutedEventArgs e) => InputBox.Clear();
    }
}
