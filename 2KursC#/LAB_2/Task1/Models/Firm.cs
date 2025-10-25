using System;

namespace Task1
{
    public sealed class Firm
    {
        public string Name { get; }
        public DateTime FoundedAt { get; }
        public BusinessProfile Profile { get; }
        public Person Director { get; }
        public int EmployeeCount { get; }
        public Address Address { get; }

        public Firm(string name, DateTime foundedAt, BusinessProfile profile, Person director, int employeeCount, Address address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));

            if (employeeCount < 0)
                throw new ArgumentOutOfRangeException(nameof(employeeCount));

            Name = name;
            FoundedAt = foundedAt;
            Profile = profile;
            Director = director ?? throw new ArgumentNullException(nameof(director));
            EmployeeCount = employeeCount;
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public override string ToString()
            => $"{Name} | {Profile} | Founded: {FoundedAt:yyyy-MM-dd} | Dir: {Director.FullName} | Employees: {EmployeeCount} | {Address}";
    }
}