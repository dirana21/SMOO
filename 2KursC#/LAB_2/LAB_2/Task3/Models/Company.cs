using System.Collections.Generic;

namespace Task3
{
    public sealed class Company
    {
        public string Name { get; set; }
        public President President { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Worker> Workers { get; set; }

        public Company()
        {
            Managers = new List<Manager>();
            Workers = new List<Worker>();
        }

        public override string ToString()
            => $"{Name} | President: {President?.LastName} {President?.FirstName} | Managers: {Managers.Count} | Workers: {Workers.Count}";
    }
}