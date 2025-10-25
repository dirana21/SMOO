using System.Windows;
using System.Windows.Input;
using Task2.Utils;           
using Task2.ViewModels;      

namespace Task2.Views
{
    public partial class GameView : Window
    {
        public GameView()
        {
            InitializeComponent();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is GameViewModel vm)
                vm.NewGameCommand.Execute(null);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataContext is not GameViewModel vm) return;

            if (e.Key == Key.Left) vm.MoveCommand.Execute(Direction.Left);
            else if (e.Key == Key.Right) vm.MoveCommand.Execute(Direction.Right);
            else if (e.Key == Key.Up) vm.MoveCommand.Execute(Direction.Up);
            else if (e.Key == Key.Down) vm.MoveCommand.Execute(Direction.Down);
        }
    }
}
