using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Services
{
    public interface IRandomService
    {
        int Next(int minInclusive, int maxExclusive);
        double NextDouble();
    }

    public sealed class RandomService : IRandomService
    {
        private readonly Random _rnd = new();
        public int Next(int minInclusive, int maxExclusive) => _rnd.Next(minInclusive, maxExclusive);
        public double NextDouble() => _rnd.NextDouble();
    }
}
