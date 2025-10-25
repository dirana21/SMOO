using System;

namespace Task3
{
    public sealed class Manager : Employer
    {
        public string Department { get; set; }

        public Manager()
        {
            
        }

        public Manager(string firstName, string lastName, DateTime birthDate,
            decimal baseSalary, EducationLevel education, int yearsExperience,
            string department)
            : base(firstName, lastName, birthDate, baseSalary, education, yearsExperience)
        {
            Department = department;
        }
    }
}