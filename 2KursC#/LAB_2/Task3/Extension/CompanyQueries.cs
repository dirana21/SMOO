using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public static class CompanyQueries
    {
        private static StringComparison Ci => StringComparison.OrdinalIgnoreCase;

        
        public static int EmployeesCountTotal(this Company c)
            => (c?.Workers?.Count ?? 0) + (c?.Managers?.Count ?? 0) + (c?.President != null ? 1 : 0);

        
        public static int WorkersCountOnly(this Company c)
            => c?.Workers?.Count ?? 0;

        
        public static decimal TotalPayroll(this Company c)
        {
            if (c == null) return 0m;
            var pres = c.President != null ? c.President.BaseSalary : 0m;
            var mgrs = (c.Managers ?? new List<Manager>()).Sum(m => m.BaseSalary);
            var wrks = (c.Workers ?? new List<Worker>()).Sum(w => w.BaseSalary);
            return pres + mgrs + wrks;
        }

        
        public static IEnumerable<Worker> Top10MostExperiencedWorkers(this Company c)
            => (c?.Workers ?? new List<Worker>())
               .OrderByDescending(w => w.YearsExperience)
               .ThenBy(w => w.LastName)
               .ThenBy(w => w.FirstName)
               .Take(10);

        
        public static Worker YoungestWithHigherEducationAmongTop10(this Company c)
            => c.Top10MostExperiencedWorkers()
                .Where(w => w.Education == EducationLevel.Higher)
                .OrderByDescending(w => w.BirthDate) 
                .FirstOrDefault();

        
        public static Manager YoungestManager(this Company c)
            => (c?.Managers ?? new List<Manager>())
               .OrderByDescending(m => m.BirthDate)
               .FirstOrDefault();

        public static Manager OldestManager(this Company c)
            => (c?.Managers ?? new List<Manager>())
               .OrderBy(m => m.BirthDate)
               .FirstOrDefault();

       
        public static IDictionary<WorkerSpecialty, List<Worker>> OctoberBornWorkersBySpecialty(this Company c)
            => (c?.Workers ?? new List<Worker>())
               .Where(w => w.BirthDate.Month == 10)
               .GroupBy(w => w.Specialty)
               .OrderBy(g => g.Key.ToString())
               .ToDictionary(g => g.Key, g => g.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList());

        
        public static IEnumerable<Employer> AllNamedVolodymyr(this Company c)
        {
            var all = new List<Employer>();
            if (c?.President != null) all.Add(c.President);
            if (c?.Managers != null) all.AddRange(c.Managers);
            if (c?.Workers != null) all.AddRange(c.Workers);

            return all.Where(e => string.Equals(e.FirstName, "Volodymyr", Ci));
        }

        public static Employer YoungestVolodymyr(this Company c)
            => c.AllNamedVolodymyr()
                .OrderByDescending(v => v.BirthDate)
                .FirstOrDefault();

        public static decimal YoungestVolodymyrBonusAmount(this Company c)
        {
            var v = c.YoungestVolodymyr();
            return v != null ? Math.Round(v.BaseSalary / 3m, 2) : 0m;
        }
    }
}