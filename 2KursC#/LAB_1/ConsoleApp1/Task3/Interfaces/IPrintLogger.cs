using System.Collections.Generic;

namespace Task3
{
    public interface IPrintLogger
    {
        void Log(PrintJob job);
        IEnumerable<PrintJob> GetLogs();
    }
}