using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public sealed class InMemoryPhoneRepository : IPhoneRepository
    {
        private readonly List<Phone> _phones;
        public InMemoryPhoneRepository(IEnumerable<Phone> seed) => _phones = seed?.ToList() ?? new();
        public IQueryable<Phone> Query() => _phones.AsQueryable();
    }
}