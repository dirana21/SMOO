using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class PriorityPrintQueue : IPrintQueue
    {
        private readonly List<PrintJob> _queue = new List<PrintJob>();

        public void AddJob(PrintJob job)
        {
            _queue.Add(job);
            _queue.Sort((a, b) =>
            {
                int priorityCompare = b.Priority.CompareTo(a.Priority);
                return priorityCompare != 0 ? priorityCompare : a.RequestTime.CompareTo(b.RequestTime);
            });
        }

        public PrintJob GetNextJob()
        {
            if (_queue.Count == 0) return null;
            var job = _queue[0];
            _queue.RemoveAt(0);
            return job;
        }

        public bool HasJobs() => _queue.Any();
    }
}