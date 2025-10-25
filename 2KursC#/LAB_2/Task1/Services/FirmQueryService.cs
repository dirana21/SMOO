using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public sealed class FirmQueryService : IFirmQueryService
    {
        private readonly IFirmRepository _repo;
        public FirmQueryService(IFirmRepository repo) => _repo = repo;

        public IEnumerable<Firm> GetAll() => _repo.Query().GetAll().ToList();
        public IEnumerable<Firm> WithNameFood() => _repo.Query().WithNameFood().ToList();
        public IEnumerable<Firm> InMarketing() => _repo.Query().InMarketing().ToList();
        public IEnumerable<Firm> InMarketingOrIT() => _repo.Query().InMarketingOrIT().ToList();
        public IEnumerable<Firm> WithEmployeesMoreThan100() => _repo.Query().WithEmployeesMoreThan100().ToList();
        public IEnumerable<Firm> WithEmployeesBetween100And300() => _repo.Query().WithEmployeesBetween100And300().ToList();
        public IEnumerable<Firm> LocatedInLondon() => _repo.Query().LocatedInLondon().ToList();
        public IEnumerable<Firm> DirectorLastNameWhite() => _repo.Query().DirectorLastNameWhite().ToList();
        public IEnumerable<Firm> FoundedOverTwoYearsAgo(DateTime? now = null) => _repo.Query().FoundedOverTwoYearsAgo(now).ToList();
        public IEnumerable<Firm> FoundedOver150DaysAgo(DateTime? now = null) => _repo.Query().FoundedOver150DaysAgo(now).ToList();
        public IEnumerable<Firm> DirectorBlackAndNameContainsWhite() => _repo.Query().DirectorBlackAndNameContainsWhite().ToList();
    }
}