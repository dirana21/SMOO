namespace Task3
{
    public interface IPrintQueue
    {
        void AddJob(PrintJob job);
        PrintJob GetNextJob();
        bool HasJobs();
    }
}