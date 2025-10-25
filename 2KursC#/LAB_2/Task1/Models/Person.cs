using System.Linq;

namespace Task1
{
    public sealed class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }

        public Person(string firstName, string lastName, string middleName = "")
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName ?? string.Empty;
        }

        public string FullName => string.Join(" ",
            new[] { LastName, FirstName, MiddleName }.Where(x => !string.IsNullOrWhiteSpace(x)));
    }
}