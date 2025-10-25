using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace LAB_3.Views.Task5View
{
    public partial class Task5View : UserControl
    {
        public Task5View() => InitializeComponent();

        private void OnConvert(object sender, RoutedEventArgs e)
        {
            // допускаем точку и запятую
            var text = TbLb.Text.Replace(',', '.');
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var pounds) && pounds >= 0)
            {
                const double KgPerLb = 0.45359237;
                TbKg.Text = (pounds * KgPerLb).ToString("0.###", CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show("Enter a valid non-negative number in pounds.");
            }
        }
    }
}
