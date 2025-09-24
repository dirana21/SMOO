namespace Task3
{
    public class ProgrammersDayChecker
    {
        public static Func<DateTime, bool> IsProgrammerDay = date => date.DayOfYear == 256;
    }
}