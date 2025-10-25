using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public sealed class PhoneQueryService : IPhoneQueryService
    {
        private readonly IPhoneRepository _repo;
        public PhoneQueryService(IPhoneRepository repo) => _repo = repo;

        public int CountAll() => _repo.Query().CountAll();
        public int CountPriceGreaterThan(decimal price) => _repo.Query().CountPriceGreaterThan(price);
        public int CountPriceInRange(decimal min, decimal max) => _repo.Query().CountPriceInRange(min, max);
        public int CountByManufacturer(string manufacturer) => _repo.Query().CountByManufacturer(manufacturer);

        public Phone? MinPricePhone() => _repo.Query().MinPricePhone();
        public Phone? MaxPricePhone() => _repo.Query().MaxPricePhone();
        public Phone? OldestPhone() => _repo.Query().OldestPhone();
        public Phone? NewestPhone() => _repo.Query().NewestPhone();

        public decimal? AveragePrice() => _repo.Query().AveragePrice();

        public IEnumerable<Phone> TopMostExpensive(int take) => _repo.Query().TopMostExpensive(take).ToList();
        public IEnumerable<Phone> TopCheapest(int take) => _repo.Query().TopCheapest(take).ToList();
        public IEnumerable<Phone> TopOldest(int take) => _repo.Query().TopOldest(take).ToList();
        public IEnumerable<Phone> TopNewest(int take) => _repo.Query().TopNewest(take).ToList();

        public IEnumerable<ManufacturerCount> ManufacturerStats() => _repo.Query().ManufacturerStats().ToList();
        public IEnumerable<ModelCount> ModelStats() => _repo.Query().ModelStats().ToList();
        public IEnumerable<YearCount> YearStats() => _repo.Query().YearStats().ToList();
    }
}