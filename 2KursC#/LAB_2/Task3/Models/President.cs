using System;

namespace Task3
{
    public sealed class President : Employer
    {
        public President()
        {
            
        }

        public President(string firstName, string lastName, DateTime birthDate,
            decimal baseSalary, EducationLevel education, int yearsExperience)
            : base(firstName, lastName, birthDate, baseSalary, education, yearsExperience)
        {
            
        }
    }
}