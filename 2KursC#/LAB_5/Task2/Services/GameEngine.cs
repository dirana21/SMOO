using System;
using Task2.Models;
using Task2.Utils;

namespace Task2.Services
{
    public sealed class GameEngine : IGameEngine
    {
        public int Size { get; }
        public Tile[,] Board { get; }
        public int Score { get; private set; }
        public int HighScore { get; private set; }

        private readonly IRandomService _rnd;

        public GameEngine(int size, IRandomService rnd)
        {
            Size = size;
            _rnd = rnd;
            Board = new Tile[size, size];
            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                    Board[r, c] = new Tile(0);
        }

        public void NewGame()
        {
            Score = 0;
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    Board[r, c].Value = 0;

            SpawnRandomTile();
            SpawnRandomTile();
        }

        public bool Move(Direction dir)
        {
            bool moved = false;
            
            for (int i = 0; i < Size; i++)
            {
                int[] line = new int[Size];
                for (int j = 0; j < Size; j++)
                {
                    var (r, c) = Map(i, j, dir);
                    line[j] = Board[r, c].Value;
                }

                int[] compressed = CompressLeft(line);

                int addScore = 0;
                int[] merged = MergeLeft(compressed, ref addScore);

                if (addScore > 0) Score += addScore;
                if (!ArraysEqual(line, merged)) moved = true;

                for (int j = 0; j < Size; j++)
                {
                    var (r, c) = Map(i, j, dir);
                    Board[r, c].Value = merged[j];
                }
            }

            if (moved)
            {
                SpawnRandomTile();
                if (Score > HighScore) HighScore = Score;
            }
            return moved;
        }

        public bool CanMove()
        {
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    if (Board[r, c].Value == 0) return true;

            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                {
                    int v = Board[r, c].Value;
                    if (r + 1 < Size && Board[r + 1, c].Value == v) return true;
                    if (c + 1 < Size && Board[r, c + 1].Value == v) return true;
                }
            return false;
        }

        private (int r, int c) Map(int i, int j, Direction d)
        {
            return d switch
            {
                Direction.Left => (i, j),
                Direction.Right => (i, Size - 1 - j),
                Direction.Up => (j, i),
                Direction.Down => (Size - 1 - j, i),
                _ => (i, j)
            };
        }

        private static int[] CompressLeft(int[] src)
        {
            int[] res = new int[src.Length];
            int idx = 0;
            for (int k = 0; k < src.Length; k++)
                if (src[k] != 0) res[idx++] = src[k];
            return res;
        }

        private static int[] MergeLeft(int[] src, ref int addScore)
        {
            int n = src.Length;
            int[] res = new int[n];
            int idx = 0;
            for (int k = 0; k < n; k++)
            {
                if (src[k] == 0) continue;
                if (k + 1 < n && src[k] == src[k + 1] && src[k] != 0)
                {
                    int merged = src[k] * 2;
                    res[idx++] = merged;
                    addScore += merged;
                    k++; 
                }
                else
                {
                    res[idx++] = src[k];
                }
            }
            return res;
        }

        private void SpawnRandomTile()
        {
            Span<(int r, int c)> free = stackalloc (int, int)[Size * Size];
            int count = 0;
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    if (Board[r, c].Value == 0) free[count++] = (r, c);

            if (count == 0) return;

            var pick = free[_rnd.Next(0, count)];
            int value = _rnd.NextDouble() < 0.9 ? 2 : 4; 
            Board[pick.r, pick.c].Value = value;
        }

        private static bool ArraysEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
    }
}
