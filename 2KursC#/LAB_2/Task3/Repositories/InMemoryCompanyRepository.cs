using System;
using System.Collections.Generic;

namespace Task3
{
    public sealed class InMemoryCompanyRepository : ICompanyRepository
    {
        private readonly Company _company;

        public InMemoryCompanyRepository(Company company)
        {
            _company = company ?? new Company();
        }

        public Company GetCompany() => _company;
        
        public static InMemoryCompanyRepository CreateDemo()
        {
            var company = new Company
            {
                Name = "TechWorks Ltd",
                President = new President("Oleg", "Kovalenko", new DateTime(1970, 4, 2), 12000m, EducationLevel.Higher, 30),
                Managers = new List<Manager>
                {
                    new Manager("Iryna", "Sydorenko", new DateTime(1988, 10, 5), 5000m, EducationLevel.Higher, 12, "Production"),
                    new Manager("Pavlo", "Levchenko", new DateTime(1995, 3, 11), 4200m, EducationLevel.Higher, 7, "QA"),
                    new Manager("Maryna", "Kravchuk", new DateTime(1982, 12, 20), 5300m, EducationLevel.Higher, 15, "R&D"),
                    new Manager("Andrii", "Shevchenko", new DateTime(1979, 7, 9), 5600m, EducationLevel.Vocational, 18, "Logistics")
                },
                Workers = new List<Worker>
                {
                    new Worker("Volodymyr", "Ivanov",  new DateTime(1999,10,12), 2000m, EducationLevel.Higher, 5, WorkerSpecialty.Electrician),
                    new Worker("Serhii",    "Petrenko",new DateTime(1987, 2, 15), 2100m, EducationLevel.Vocational, 10, WorkerSpecialty.Welder),
                    new Worker("Vadym",     "Bondar",  new DateTime(1995,10, 1), 2050m, EducationLevel.Secondary, 6, WorkerSpecialty.Assembler),
                    new Worker("Oleksii",   "Orlyk",   new DateTime(1992, 5, 30), 2300m, EducationLevel.Higher, 9, WorkerSpecialty.QA),
                    new Worker("Mykyta",    "Demchuk", new DateTime(2001,10,21), 1950m, EducationLevel.Higher, 3, WorkerSpecialty.Packer),
                    new Worker("Volodymyr", "Starchenko",new DateTime(1984, 8,  7), 2400m, EducationLevel.Vocational, 14, WorkerSpecialty.Mechanic),
                    new Worker("Ihor",      "Romanyuk", new DateTime(1990, 1, 17), 2250m, EducationLevel.Higher, 11, WorkerSpecialty.Electrician),
                    new Worker("Vasyl",     "Humeniuk", new DateTime(1981,10, 9), 2600m, EducationLevel.Vocational, 19, WorkerSpecialty.Welder),
                    new Worker("Volodymyr", "Kravets", new DateTime(2003, 4, 23), 1900m, EducationLevel.Secondary, 2, WorkerSpecialty.Loader),
                    new Worker("Dmytro",    "Semenov", new DateTime(1997, 6, 14), 2150m, EducationLevel.Higher, 7, WorkerSpecialty.QA),
                    new Worker("Anton",     "Melnyk", new DateTime(1989,10,29), 2350m, EducationLevel.Higher, 12, WorkerSpecialty.Assembler),
                    new Worker("Yurii",     "Fedorchuk",new DateTime(1993, 3,  5), 2200m, EducationLevel.Higher, 8, WorkerSpecialty.Mechanic),
                    new Worker("Stanislav", "Taran",   new DateTime(1986,11,18), 2450m, EducationLevel.Vocational, 15, WorkerSpecialty.Other),
                    new Worker("Petro",     "Klymchuk", new DateTime(1991,10, 3), 2100m, EducationLevel.Secondary, 9, WorkerSpecialty.Packer)
                }
            };

            return new InMemoryCompanyRepository(company);
        }
    }
}