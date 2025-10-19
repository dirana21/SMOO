namespace Task1
{
    public sealed class Address
    {
        public string Country { get; }
        public string City { get; }
        public string Street { get; }

        public Address(string country, string city, string street = "")
        {
            Country = country;
            City = city;
            Street = street;
        }

        public override string ToString() => $"{Street}, {City}, {Country}".Trim(',', ' ');
    }
}