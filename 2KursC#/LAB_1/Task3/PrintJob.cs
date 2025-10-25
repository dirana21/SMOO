using System;

namespace Task3
{
    public class PrintJob
    {
        public string User { get; }
        public string DocumentName { get; }
        public PrintPriority Priority { get; }
        public DateTime RequestTime { get; }

        public PrintJob(string user, string documentName, PrintPriority priority)
        {
            User = user;
            DocumentName = documentName;
            Priority = priority;
            RequestTime = DateTime.Now;
        }

        public override string ToString() => $"[{Priority}] {User} - {DocumentName} ({RequestTime})";
    }
}