using System.Windows;
using LAB_5.Views.Auth;

namespace LAB_5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnOpenLogin(object sender, RoutedEventArgs e)
        {
            var w = new LoginWindow { Owner = this };
            Hide();
            w.ShowDialog();
            Show();
        }

        private void OnOpenRegister(object sender, RoutedEventArgs e)
        {
            var w = new RegistrationWindow { Owner = this };
            Hide();
            w.ShowDialog();
            Show();
        }
    }
}
