using System.Collections.Generic;

namespace Task2
{
    public interface IPhoneQueryService
    {
        
        int CountAll();
        int CountPriceGreaterThan(decimal price);
        int CountPriceInRange(decimal min, decimal max);
        int CountByManufacturer(string manufacturer);
        
        Phone? MinPricePhone();
        Phone? MaxPricePhone();
        Phone? OldestPhone();
        Phone? NewestPhone();
        
        decimal? AveragePrice();
        
        IEnumerable<Phone> TopMostExpensive(int take);
        IEnumerable<Phone> TopCheapest(int take);
        IEnumerable<Phone> TopOldest(int take);
        IEnumerable<Phone> TopNewest(int take);
        
        IEnumerable<ManufacturerCount> ManufacturerStats();
        IEnumerable<ModelCount> ModelStats();
        IEnumerable<YearCount> YearStats();
    }
}