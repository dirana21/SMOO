using System.Collections.Generic;

namespace Task2
{
    public interface IFileProvider
    {
        IEnumerable<string> GetAvailableFiles();
    }
}