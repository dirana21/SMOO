using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    public sealed class Tile
    {
        public int Value { get; set; }
        public Tile(int value) => Value = value;
        public bool IsEmpty => Value == 0;
    }
}
