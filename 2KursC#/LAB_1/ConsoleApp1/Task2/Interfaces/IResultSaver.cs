using System.Collections.Generic;

namespace Task2
{
    public interface IResultSaver
    {
        void Save(Dictionary<string, int> wordStats, string filePath);
    }
}