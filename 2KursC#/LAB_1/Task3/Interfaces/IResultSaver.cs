using System.Collections.Generic;

namespace Task3
{
    public interface IResultSaver
    {
        void Save(IEnumerable<PrintJob> jobs, string filePath);
    }
}