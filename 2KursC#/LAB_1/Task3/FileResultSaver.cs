using System.Collections.Generic;
using System.IO;

namespace Task3
{
    public class FileResultSaver : IResultSaver
    {
        public void Save(IEnumerable<PrintJob> jobs, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            foreach (var job in jobs)
                writer.WriteLine(job);
        }
    }
}