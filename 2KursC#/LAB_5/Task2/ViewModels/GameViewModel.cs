using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task2.Services;
using Task2.Utils;

namespace Task2.ViewModels
{
    public sealed class GameViewModel : INotifyPropertyChanged
    {
        private readonly IGameEngine _engine;
        public ObservableCollection<int> Cells { get; } = new(); 

        public int Score => _engine.Score;
        public int HighScore => _engine.HighScore;

        public RelayCommand NewGameCommand { get; }
        public RelayCommand MoveCommand { get; } 

        public GameViewModel()
        {
            _engine = new GameEngine(4, new RandomService());
            for (int i = 0; i < 16; i++) Cells.Add(0);

            NewGameCommand = new RelayCommand(_ => { _engine.NewGame(); Sync(); });
            MoveCommand = new RelayCommand(p =>
            {
                if (p is Direction d && _engine.Move(d))
                {
                    Sync();
                    if (!_engine.CanMove())
                    {
                        
                    }
                }
            });

            _engine.NewGame();
            Sync();
        }

        private void Sync()
        {
            int k = 0;
            for (int r = 0; r < _engine.Size; r++)
                for (int c = 0; c < _engine.Size; c++)
                {
                    Cells[k] = _engine.Board[r, c].Value;
                    k++;
                }
            OnPropertyChanged(nameof(Score));
            OnPropertyChanged(nameof(HighScore));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
