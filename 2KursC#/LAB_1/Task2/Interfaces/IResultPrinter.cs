using System.Collections.Generic;

namespace Task2
{
    public interface IResultPrinter
    {
        void Print(Dictionary<string, int> wordStats);
    }
}