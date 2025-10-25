using System.Linq;

namespace Task2
{
    public interface IPhoneRepository
    {
        IQueryable<Phone> Query();
    }
}