using System.Collections.Generic;

namespace Task3
{
    public class PrintLogger : IPrintLogger
    {
        private readonly List<PrintJob> _logs = new List<PrintJob>();

        public void Log(PrintJob job) => _logs.Add(job);

        public IEnumerable<PrintJob> GetLogs() => _logs;
    }
}