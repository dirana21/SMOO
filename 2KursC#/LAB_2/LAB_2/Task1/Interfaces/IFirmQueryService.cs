using System;
using System.Collections.Generic;

namespace Task1
{
    public interface IFirmQueryService
    {
        IEnumerable<Firm> GetAll();
        IEnumerable<Firm> WithNameFood();
        IEnumerable<Firm> InMarketing();
        IEnumerable<Firm> InMarketingOrIT();
        IEnumerable<Firm> WithEmployeesMoreThan100();
        IEnumerable<Firm> WithEmployeesBetween100And300();
        IEnumerable<Firm> LocatedInLondon();
        IEnumerable<Firm> DirectorLastNameWhite();
        IEnumerable<Firm> FoundedOverTwoYearsAgo(DateTime? now = null);
        IEnumerable<Firm> FoundedOver150DaysAgo(DateTime? now = null);
        IEnumerable<Firm> DirectorBlackAndNameContainsWhite();
    }
}