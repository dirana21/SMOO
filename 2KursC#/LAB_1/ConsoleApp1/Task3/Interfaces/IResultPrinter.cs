using System.Collections.Generic;

namespace Task3
{
    public interface IResultPrinter
    {
        void Print(IEnumerable<PrintJob> jobs);
    }
}