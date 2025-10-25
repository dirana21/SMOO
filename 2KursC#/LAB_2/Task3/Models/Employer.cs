using System;

namespace Task3
{
    public abstract class Employer
    {
        public string FirstName { get; set; }           
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal BaseSalary { get; set; }         
        public EducationLevel Education { get; set; }
        public int YearsExperience { get; set; }

        protected Employer()
        {
            
        }

        protected Employer(string firstName, string lastName, DateTime birthDate,
            decimal baseSalary, EducationLevel education, int yearsExperience)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Education = education;
            YearsExperience = yearsExperience;
        }

        public int AgeYears(DateTime? now = null)
        {
            var today = (now ?? DateTime.Today);
            var age = today.Year - BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        public override string ToString()
            => $"{GetType().Name}: {LastName} {FirstName} | Age: {AgeYears()} | Salary: {BaseSalary:0.##} | Edu: {Education} | Exp: {YearsExperience}y";
    }
}