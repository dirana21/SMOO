using System;
using System.Linq;

namespace Task1
{
    public static class FirmQueries
    {
        private static StringComparison Ci => StringComparison.OrdinalIgnoreCase;

        public static IQueryable<Firm> GetAll(this IQueryable<Firm> q) => q;

        public static IQueryable<Firm> WithNameFood(this IQueryable<Firm> q)
            => q.Where(f => string.Equals(f.Name, "Food", Ci));

        public static IQueryable<Firm> InMarketing(this IQueryable<Firm> q)
            => q.Where(f => f.Profile == BusinessProfile.Marketing);

        public static IQueryable<Firm> InMarketingOrIT(this IQueryable<Firm> q)
            => q.Where(f => f.Profile == BusinessProfile.Marketing || f.Profile == BusinessProfile.IT);

        public static IQueryable<Firm> WithEmployeesMoreThan100(this IQueryable<Firm> q)
            => q.Where(f => f.EmployeeCount > 100);

        public static IQueryable<Firm> WithEmployeesBetween100And300(this IQueryable<Firm> q)
            => q.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300);

        public static IQueryable<Firm> LocatedInLondon(this IQueryable<Firm> q)
            => q.Where(f => string.Equals(f.Address.City, "London", Ci));

        public static IQueryable<Firm> DirectorLastNameWhite(this IQueryable<Firm> q)
            => q.Where(f => string.Equals(f.Director.LastName, "White", Ci));

        public static IQueryable<Firm> FoundedOverTwoYearsAgo(this IQueryable<Firm> q, DateTime? now = null)
        {
            var date = now ?? DateTime.Today;
            return q.Where(f => f.FoundedAt < date.AddYears(-2));
        }

        public static IQueryable<Firm> FoundedOver150DaysAgo(this IQueryable<Firm> q, DateTime? now = null)
        {
            var date = now ?? DateTime.Today;
            return q.Where(f => f.FoundedAt < date.AddDays(-150));
        }

        public static IQueryable<Firm> DirectorBlackAndNameContainsWhite(this IQueryable<Firm> q)
            => q.Where(f =>
                string.Equals(f.Director.LastName, "Black", Ci) &&
                f.Name.IndexOf("White", Ci) >= 0);
    }
}