namespace Task3
{
    public class ProgrammersDayChecker
    {
        public static bool IsProgrammersDay(DateTime date)
        {
            return date.DayOfYear == 256;
        }
    }
}