using System.Linq;

namespace Task1
{
    public interface IFirmRepository
    {
        IQueryable<Firm> Query();
    }
}