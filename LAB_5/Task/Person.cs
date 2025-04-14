namespace LAB_5
{
    public class Person
    {
        private string? firstName;
        private string? lastName;
        private DateTime dateOfBirth;

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }

        public Person()
        {
            this.firstName = null;
            this.lastName = null;
            this.dateOfBirth = new DateTime();
        }

        public string? FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string? LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public DateTime? DateOfBirth
        {
            get => dateOfBirth;
            set => dateOfBirth = (DateTime)value!;
        }

        public int BirthYear
        {
            get { return dateOfBirth.Year; }
            set { dateOfBirth = new DateTime(value, dateOfBirth.Month,dateOfBirth.Day); }
        }

        public override string ToString()
        {
            return $"Ім'я: {firstName}, Прізвище: {lastName}, Дата народження: {dateOfBirth.ToShortDateString()}";
        }

        public string ToShortString()
        {
            return $"Ім'я: {firstName}, Прізвище: {lastName}";
        }
    }
}

