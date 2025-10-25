using System;
using System.Linq;

namespace Task2
{
    public static class PhoneQueries
    {
        private static StringComparison Ci => StringComparison.OrdinalIgnoreCase;

        // Підрахунки
        public static int CountAll(this IQueryable<Phone> q) => q.Count();
        public static int CountPriceGreaterThan(this IQueryable<Phone> q, decimal price)
            => q.Count(p => p.Price > price);
        public static int CountPriceInRange(this IQueryable<Phone> q, decimal min, decimal max)
            => q.Count(p => p.Price >= min && p.Price <= max);
        public static int CountByManufacturer(this IQueryable<Phone> q, string manufacturer)
            => q.Count(p => string.Equals(p.Manufacturer, manufacturer, Ci));

        // Мін/Макс/дата
        public static Phone? MinPricePhone(this IQueryable<Phone> q)
            => q.OrderBy(p => p.Price).FirstOrDefault();

        public static Phone? MaxPricePhone(this IQueryable<Phone> q)
            => q.OrderByDescending(p => p.Price).FirstOrDefault();

        public static Phone? OldestPhone(this IQueryable<Phone> q)
            => q.OrderBy(p => p.ReleaseDate).FirstOrDefault();

        public static Phone? NewestPhone(this IQueryable<Phone> q)
            => q.OrderByDescending(p => p.ReleaseDate).FirstOrDefault();

        // Середня ціна (null, якщо колекція порожня)
        public static decimal? AveragePrice(this IQueryable<Phone> q)
            => q.Any() ? q.Average(p => p.Price) : (decimal?)null;

        // Топи
        public static IQueryable<Phone> TopMostExpensive(this IQueryable<Phone> q, int take)
            => q.OrderByDescending(p => p.Price).Take(take);

        public static IQueryable<Phone> TopCheapest(this IQueryable<Phone> q, int take)
            => q.OrderBy(p => p.Price).Take(take);

        public static IQueryable<Phone> TopOldest(this IQueryable<Phone> q, int take)
            => q.OrderBy(p => p.ReleaseDate).Take(take);

        public static IQueryable<Phone> TopNewest(this IQueryable<Phone> q, int take)
            => q.OrderByDescending(p => p.ReleaseDate).Take(take);

        // Статистика
        public static IQueryable<ManufacturerCount> ManufacturerStats(this IQueryable<Phone> q)
            => q.GroupBy(p => p.Manufacturer)
                .OrderByDescending(g => g.Count())
                .Select(g => new ManufacturerCount { Manufacturer = g.Key, Count = g.Count() });

        public static IQueryable<ModelCount> ModelStats(this IQueryable<Phone> q)
            => q.GroupBy(p => p.Name)
                .OrderByDescending(g => g.Count())
                .Select(g => new ModelCount { Model = g.Key, Count = g.Count() });

        public static IQueryable<YearCount> YearStats(this IQueryable<Phone> q)
            => q.GroupBy(p => p.ReleaseDate.Year)
                .OrderByDescending(g => g.Key)
                .Select(g => new YearCount { Year = g.Key, Count = g.Count() });
    }
}