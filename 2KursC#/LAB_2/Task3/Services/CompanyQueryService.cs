using System.Collections.Generic;

namespace Task3
{
    public sealed class CompanyQueryService : ICompanyQueryService
    {
        private readonly ICompanyRepository _repo;

        public CompanyQueryService(ICompanyRepository repo)
        {
            _repo = repo;
        }

        private Company C() => _repo.GetCompany();

        public int EmployeesCountTotal() => C().EmployeesCountTotal();
        public int WorkersCountOnly() => C().WorkersCountOnly();

        public decimal TotalPayroll() => C().TotalPayroll();

        public IEnumerable<Worker> Top10MostExperiencedWorkers() => C().Top10MostExperiencedWorkers();
        public Worker YoungestWithHigherEducationAmongTop10() => C().YoungestWithHigherEducationAmongTop10();

        public Manager YoungestManager() => C().YoungestManager();
        public Manager OldestManager() => C().OldestManager();

        public IDictionary<WorkerSpecialty, List<Worker>> OctoberBornWorkersBySpecialty()
            => C().OctoberBornWorkersBySpecialty();

        public IEnumerable<Employer> AllNamedVolodymyr() => C().AllNamedVolodymyr();
        public Employer YoungestVolodymyr() => C().YoungestVolodymyr();
        public decimal YoungestVolodymyrBonusAmount() => C().YoungestVolodymyrBonusAmount();
    }
}