using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LAB_3.Views.Task4View
{
    public partial class Task4View : UserControl
    {
        public Task4View() => InitializeComponent();

        private void OnToggle(object sender, RoutedEventArgs e)
        {
            if (sender is Button b) b.Visibility = Visibility.Collapsed;
            var allHidden = new[] { B1, B2, B3, B4, B5 }.All(btn => btn.Visibility != Visibility.Visible);
            if (allHidden) MessageBox.Show("You hid all the buttons!");
        }
    }
}
