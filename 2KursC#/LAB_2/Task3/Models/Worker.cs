using System;

namespace Task3
{
    public sealed class Worker : Employer
    {
        public WorkerSpecialty Specialty { get; set; }

        public Worker() { }

        public Worker(string firstName, string lastName, DateTime birthDate,
            decimal baseSalary, EducationLevel education, int yearsExperience,
            WorkerSpecialty specialty)
            : base(firstName, lastName, birthDate, baseSalary, education, yearsExperience)
        {
            Specialty = specialty;
        }

        public override string ToString()
            => base.ToString() + $" | Specialty: {Specialty}";
    }
}