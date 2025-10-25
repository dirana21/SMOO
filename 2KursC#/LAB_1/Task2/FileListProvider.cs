using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task2
{
    public class FileListProvider : IFileProvider
    {
        private readonly string _listFilePath;
        public FileListProvider(string listFilePath)
        {
            _listFilePath = listFilePath;
        }

        public IEnumerable<string> GetAvailableFiles()
        {
            if (!File.Exists(_listFilePath))
                throw new FileNotFoundException($"File {_listFilePath} not found!");

            return File.ReadAllLines(_listFilePath).Where(line => !string.IsNullOrWhiteSpace(line));
        }
    }
}