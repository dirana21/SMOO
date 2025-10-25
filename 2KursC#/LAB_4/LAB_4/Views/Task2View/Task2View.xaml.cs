using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LAB_4.Views.Task2View
{
    public partial class Task2View : UserControl
    {
        private static double _dailyRevenue = 0.0;

        private readonly Dictionary<string, double> _fuelPrices = new()
        {
            { "A-76", 58.60 }, { "A-92", 57.25 }, { "A-95", 58.60 }, { "Diesel", 55.76 }, { "Gas", 34.40 }
        };

        public Task2View()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                FuelPayCaption.Text = "To pay";
                FuelPriceBox.Text = "0.00";
                CafePayValue.Text = "0.00";
                TotalValue.Text = "0.00";
                return;
            }

            Loaded += (_, __) =>
            {
                FuelBox.ItemsSource = _fuelPrices.Keys.ToList();
                FuelBox.SelectedIndex = 0;
                RecalcFuel();
                CafeRecalc();
            };
        }

        private void OnFuelChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded) return;
            if (FuelBox.SelectedItem is string key && _fuelPrices.TryGetValue(key, out var price))
            {
                FuelPriceBox.Text = price.ToString("0.00", CultureInfo.InvariantCulture);
                RecalcFuel();
            }
        }

        private void OnModeChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded) return;

            if (RbByLiters.IsChecked == true)
            {
                LitersBox.IsEnabled = true;
                AmountBox.IsEnabled = false;
                AmountBox.Text = "";
                FuelPayCaption.Text = "To pay";
                FuelPayUnit.Text = "UAH";
                FuelUnitText.Text = "L";
            }
            else
            {
                LitersBox.IsEnabled = false;
                AmountBox.IsEnabled = true;
                LitersBox.Text = "";
                FuelPayCaption.Text = "To dispense";
                FuelPayUnit.Text = "L";
                FuelUnitText.Text = "UAH";
            }
            RecalcFuel();
        }

        private void OnFuelInputChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsLoaded) return;
            RecalcFuel();
        }

        private void RecalcFuel()
        {
            if (FuelPriceBox == null || FuelPayValue == null) return;

            double price = Parse(FuelPriceBox.Text);

            if (RbByLiters.IsChecked == true)
            {
                double liters = Parse(LitersBox?.Text);
                double sum = liters * price;
                FuelPayValue.Text = sum.ToString("0.00", CultureInfo.InvariantCulture);
            }
            else
            {
                double money = Parse(AmountBox?.Text);
                double litersToGive = price > 0 ? money / price : 0.0;
                FuelPayValue.Text = litersToGive.ToString("0.00", CultureInfo.InvariantCulture);
            }
        }

        private void OnCafeChecked(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded) return;

            if (sender == CbHotDog) QtyHotDog.IsEnabled = CbHotDog.IsChecked == true;
            if (sender == CbHamburger) QtyHamburger.IsEnabled = CbHamburger.IsChecked == true;
            if (sender == CbFries) QtyFries.IsEnabled = CbFries.IsChecked == true;
            if (sender == CbCola) QtyCola.IsEnabled = CbCola.IsChecked == true;

            CafeRecalc();
        }

        private void OnCafeQtyChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsLoaded) return;
            CafeRecalc();
        }

        private void CafeRecalc()
        {
            if (CafePayValue == null) return;

            double sum = 0.0;
            if (CbHotDog?.IsChecked == true) sum += Parse(PriceHotDog?.Text) * Parse(QtyHotDog?.Text);
            if (CbHamburger?.IsChecked == true) sum += Parse(PriceHamburger?.Text) * Parse(QtyHamburger?.Text);
            if (CbFries?.IsChecked == true) sum += Parse(PriceFries?.Text) * Parse(QtyFries?.Text);
            if (CbCola?.IsChecked == true) sum += Parse(PriceCola?.Text) * Parse(QtyCola?.Text);

            CafePayValue.Text = sum.ToString("0.00", CultureInfo.InvariantCulture);
        }

        private void OnCalcTotal(object sender, RoutedEventArgs e)
        {
            double fuel = 0.0;
            if (RbByLiters.IsChecked == true)
                fuel = Parse(FuelPayValue?.Text);
            else
                fuel = Parse(AmountBox?.Text);

            double cafe = Parse(CafePayValue?.Text);
            double total = fuel + cafe;

            TotalValue.Text = total.ToString("0.00", CultureInfo.InvariantCulture);
            _dailyRevenue += total;
        }

        private static double Parse(string? t)
        {
            if (string.IsNullOrWhiteSpace(t)) return 0.0;
            return double.TryParse(t.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out var v) ? v : 0.0;
        }

        public static double GetDailyRevenue() => _dailyRevenue;
    }
}
