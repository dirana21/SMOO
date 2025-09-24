using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    public class ZayavkaService
    {
        private readonly IZayavkaRepository _repository;
        private List<ZayavkaNaAviabilet> _zayavky;

        public ZayavkaService(IZayavkaRepository repository)
        {
            _repository = repository;
            _zayavky = (List<ZayavkaNaAviabilet>)_repository.Load();
        }

        public void Add(ZayavkaNaAviabilet z)
        {
            _zayavky.Add(z);
            _repository.Save(_zayavky);
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < _zayavky.Count)
            {
                _zayavky.RemoveAt(index);
                _repository.Save(_zayavky);
            }
        }

        public void Edit(int index, ZayavkaNaAviabilet newData)
        {
            if (index >= 0 && index < _zayavky.Count)
            {
                _zayavky[index] = newData;
                _repository.Save(_zayavky);
            }
        }

        public IEnumerable<ZayavkaNaAviabilet> Query(string nomerReysu, DateTime startDate, DateTime endDate)
        {
            return _zayavky.Where(z => z.NomerReysu == nomerReysu &&
                                       z.DataVylotu >= startDate &&
                                       z.DataVylotu <= endDate);
        }

        public void PrintToFile(IEnumerable<ZayavkaNaAviabilet> result, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var z in result)
                {
                    sw.WriteLine(z);
                }
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i < _zayavky.Count; i++)
            {
                Console.WriteLine($"[{i}] {_zayavky[i]}");
            }
        }
    }
}