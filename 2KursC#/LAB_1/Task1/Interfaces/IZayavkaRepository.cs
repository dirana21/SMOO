using System.Collections.Generic;

namespace Task1
{
    public interface IZayavkaRepository
    {
        void Save(IEnumerable<ZayavkaNaAviabilet> data);
        IEnumerable<ZayavkaNaAviabilet> Load();
    }
}