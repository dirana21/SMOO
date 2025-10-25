using LAB_5.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace LAB_5.Views.Auth
{
    public partial class RegistrationWindow : Window
    {
        private readonly UserStore _store = new(Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "BestOil", "users.json"));

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void OnRegister(object sender, RoutedEventArgs e)
        {
            lblError.Text = "";

            var username = tbUsername.Text.Trim();
            var email = tbEmail.Text.Trim();
            var pass = pbPassword.Password;
            var confirm = pbConfirm.Password;

            if (username.Length < 3) { lblError.Text = "Username must be at least 3 characters."; return; }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) { lblError.Text = "Invalid email."; return; }
            if (pass.Length < 6) { lblError.Text = "Password must be at least 6 characters."; return; }
            if (pass != confirm) { lblError.Text = "Passwords do not match."; return; }
            if (_store.Exists(username, email)) { lblError.Text = "User with this username or email already exists."; return; }

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = User.HashPassword(pass),
                FirstName = tbFirst.Text.Trim(),
                LastName = tbLast.Text.Trim(),
                BirthDate = dpBirth.SelectedDate,
                Gender = rbMale.IsChecked == true ? "Male" : "Female"
            };

            _store.Add(user);
            MessageBox.Show("Registration successful.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            new LoginWindow().Show();
            Close();
        }

        private void OnGoLogin(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
    }
}
