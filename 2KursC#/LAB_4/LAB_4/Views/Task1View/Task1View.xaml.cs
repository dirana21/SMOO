using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LAB_4.Views.Task1View
{
    public partial class Task1View : UserControl
    {
        public Task1View() => InitializeComponent();

        double? _acc;                
        string _pendingOp = null;    
        bool _overwrite = true;      

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
       
        string CurrentText
        {
            get => DisplayBox.Text;
            set => DisplayBox.Text = value;
        }

        double CurrentValue
        {
            get
            {
                var t = CurrentText.Replace(',', '.');
                return double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out var v) ? v : 0.0;
            }
            set => CurrentText = value.ToString("G15", CultureInfo.InvariantCulture).Replace('.', ',');
        }

        void SetHistory(string text) => HistoryBox.Text = text;

        private void OnDigit(object sender, RoutedEventArgs e)
        {
            var d = ((Button)sender).Content.ToString();
            if (_overwrite || CurrentText == "0")
            {
                CurrentText = d;
                _overwrite = false;
            }
            else
            {
                CurrentText += d;
            }
        }

        private void OnDecimal(object sender, RoutedEventArgs e)
        {
            if (_overwrite)
            {
                CurrentText = "0,";
                _overwrite = false;
            }
            else if (!CurrentText.Contains(","))
            {
                CurrentText += ",";
            }
        }

        private void OnSign(object sender, RoutedEventArgs e)
        {
            if (CurrentText.StartsWith("-"))
                CurrentText = CurrentText[1..];
            else if (CurrentText != "0")
                CurrentText = "-" + CurrentText;
        }

        private void OnClearEntry(object sender, RoutedEventArgs e)
        {
            CurrentText = "0";
            _overwrite = true;
        }

        private void OnClearAll(object sender, RoutedEventArgs e)
        {
            _acc = null; _pendingOp = null;
            CurrentText = "0";
            SetHistory("");
            _overwrite = true;
        }

        private void OnBackspace(object sender, RoutedEventArgs e)
        {
            if (_overwrite) return;
            var t = CurrentText;
            if (t.Length > 1) CurrentText = t[..^1];
            else { CurrentText = "0"; _overwrite = true; }
        }

        private void OnUnaryOp(object sender, RoutedEventArgs e)
        {
            var tag = ((Button)sender).Content.ToString();
            var x = CurrentValue;
            double res;

            try
            {
                res = tag switch
                {
                    "√x" => x < 0 ? throw new ArgumentException("It is impossible to calculate √ from a negative") : Math.Sqrt(x),
                    "x²" => x * x,
                    "1/x" => Math.Abs(x) < double.Epsilon ? throw new DivideByZeroException() : 1.0 / x,
                    _ => x
                };
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); return; }

            SetHistory($"{tag}({Format(x)})");
            CurrentValue = res;
            _overwrite = true;
        }

        private void OnBinaryOp(object sender, RoutedEventArgs e)
        {
            var op = ((Button)sender).Content.ToString(); // "+", "−", "×", "÷"

            if (_acc is null)
            {
                _acc = CurrentValue;
            }
            else if (!_overwrite)
            {
                // здесь _acc точно не null, поэтому .Value
                _acc = EvalBinary(_acc.Value, CurrentValue, _pendingOp);
                CurrentValue = _acc.Value;
            }

            _pendingOp = op;
            SetHistory($"{Format(_acc ?? 0)} {op}");
            _overwrite = true;
        }

        private void OnEquals(object sender, RoutedEventArgs e)
        {
            if (_acc is null || _pendingOp is null) return;

            var right = CurrentValue;
            var res = EvalBinary(_acc.Value, right, _pendingOp);

            SetHistory($"{Format(_acc.Value)} {_pendingOp} {Format(right)} =");
            CurrentValue = res;

            _acc = null;
            _pendingOp = null;
            _overwrite = true;
        }

        private void OnPercent(object sender, RoutedEventArgs e)
        {
            if (_acc is null) return;
            var p = _acc.Value * (CurrentValue / 100.0);
            CurrentValue = p;
            _overwrite = true;
        }

        static double EvalBinary(double a, double b, string op) => op switch
        {
            "+" => a + b,
            "−" => a - b,
            "×" => a * b,
            "÷" => Math.Abs(b) < double.Epsilon ? throw new DivideByZeroException() : a / b,
            _ => b
        };

        static string Format(double v) => v.ToString("G15", CultureInfo.InvariantCulture).Replace('.', ',');

        static double PercentRelativeToAcc(double acc, double val) => acc * (val / 100.0);
    }
}
