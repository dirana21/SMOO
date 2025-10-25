using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;
using Task2.Utils;

namespace Task2.Services
{
    public interface IGameEngine
    {
        int Size { get; }
        Tile[,] Board { get; }
        int Score { get; }
        int HighScore { get; }

        void NewGame();
        bool Move(Direction direction); 
        bool CanMove();
    }
}
