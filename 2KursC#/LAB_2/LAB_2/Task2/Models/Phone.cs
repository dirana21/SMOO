using System;

namespace Task2
{
    public sealed class Phone
    {
        public string Name { get; }
        public string Manufacturer { get; }
        public decimal Price { get; }
        public DateTime ReleaseDate { get; }

        public Phone(string name, string manufacturer, decimal price, DateTime releaseDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));
            if (string.IsNullOrWhiteSpace(manufacturer))
                throw new ArgumentException("Manufacturer is required.", nameof(manufacturer));
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");

            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public override string ToString()
            => $"{Manufacturer} {Name} | ${Price} | Released: {ReleaseDate:yyyy-MM-dd}";
    }
}