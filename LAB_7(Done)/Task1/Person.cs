namespace Task1
{
    public class Person : ICloneable
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
            this.firstName = "";
            this.lastName = "";
            this.dateOfBirth = new DateTime();
        }
        
        public Person(string firstName)
        {
            this.firstName = firstName;
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

        public DateTime DateOfBirth
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
            return $" Name: {firstName}\n LastName: {lastName}\n DateOfBirth: {dateOfBirth.ToShortDateString()}";
        }

        public string ToShortString()
        {
            return $" Name: {firstName}\n LastName: {lastName}";
        }

        public object Clone()
        {
            return new Person(firstName, lastName, dateOfBirth);
        }
        
        public static Person FromString(string str)
        {
            var parts = str.Split(',');
            return new Person(parts[0]);
        }
    }
}