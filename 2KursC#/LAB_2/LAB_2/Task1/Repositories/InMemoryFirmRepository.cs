using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public sealed class InMemoryFirmRepository : IFirmRepository
    {
        private readonly List<Firm> _firms;
        public InMemoryFirmRepository(IEnumerable<Firm> seed) => _firms = seed.ToList();
        public IQueryable<Firm> Query() => _firms.AsQueryable();
    }
}