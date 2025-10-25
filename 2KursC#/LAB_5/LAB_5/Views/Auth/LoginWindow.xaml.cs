using LAB_5.Models;
using LAB_5.Views.Auth;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace LAB_5.Views.Auth
{
    public partial class LoginWindow : Window
    {
        private readonly UserStore _store = new(Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "BestOil", "users.json"));

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OnGoRegister(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            Close();
        }

        private void OnLogin(object sender, RoutedEventArgs e)
        {
            var user = _store.FindByUsername(tbUsername.Text.Trim());
            if (user == null)
            {
                Shake(this);
                MessageBox.Show("User not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var hash = User.HashPassword(pbPassword.Password);
            if (!string.Equals(hash, user.PasswordHash, StringComparison.OrdinalIgnoreCase))
            {
                Shake(this);
                MessageBox.Show("Wrong password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Welcome, {user.Username}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async void OnSocialLogin(object sender, RoutedEventArgs e)
        {
            var btn = (System.Windows.Controls.Button)sender;
            btn.IsEnabled = false;
            var original = btn.Content?.ToString() ?? "Login";

            btn.Content = "Opening...";
            await Task.Delay(700);
            btn.Content = "Authenticating...";
            await Task.Delay(900);
            btn.Content = "Success";
            await Task.Delay(500);

            btn.Content = original;
            btn.IsEnabled = true;

            var anim = new DoubleAnimation(1.0, 1.15, TimeSpan.FromMilliseconds(120))
            { AutoReverse = true, EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut } };
            btn.RenderTransform = new System.Windows.Media.ScaleTransform(1, 1);
            btn.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            btn.BeginAnimation(System.Windows.Controls.Button.OpacityProperty, null);
            btn.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleXProperty, anim);
            btn.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleYProperty, anim);
        }

        private static void Shake(Window w)
        {
            var tt = w.RenderTransform as TranslateTransform;
            if (tt == null)
            {
                tt = new TranslateTransform();
                w.RenderTransform = tt;
            }

            var anim = new DoubleAnimationUsingKeyFrames
            {
                Duration = TimeSpan.FromMilliseconds(400)
            };
            anim.KeyFrames.Add(new EasingDoubleKeyFrame(-8, KeyTime.FromPercent(0.10)));
            anim.KeyFrames.Add(new EasingDoubleKeyFrame(8, KeyTime.FromPercent(0.20)));
            anim.KeyFrames.Add(new EasingDoubleKeyFrame(-6, KeyTime.FromPercent(0.30)));
            anim.KeyFrames.Add(new EasingDoubleKeyFrame(6, KeyTime.FromPercent(0.40)));
            anim.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromPercent(0.50)));

            Storyboard.SetTarget(anim, tt);
            Storyboard.SetTargetProperty(anim, new PropertyPath(TranslateTransform.XProperty));

            var sb = new Storyboard();
            sb.Children.Add(anim);
            sb.Begin();
        }

    }
}
