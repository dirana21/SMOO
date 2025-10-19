using System.Collections.Generic;

namespace Task3
{
    public interface ICompanyQueryService
    {
        int EmployeesCountTotal();
        int WorkersCountOnly();
        
        decimal TotalPayroll();
        
        IEnumerable<Worker> Top10MostExperiencedWorkers();
        Worker YoungestWithHigherEducationAmongTop10();

        
        Manager YoungestManager();
        Manager OldestManager();
        
        IDictionary<WorkerSpecialty, List<Worker>> OctoberBornWorkersBySpecialty();
        
        IEnumerable<Employer> AllNamedVolodymyr();
        Employer YoungestVolodymyr();
        decimal YoungestVolodymyrBonusAmount(); //1.3 amount
    }
}