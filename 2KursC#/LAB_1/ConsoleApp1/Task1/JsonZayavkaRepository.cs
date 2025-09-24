using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task1
{
    public class JsonZayavkaRepository : IZayavkaRepository
    {
        private readonly string _filePath;

        public JsonZayavkaRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(IEnumerable<ZayavkaNaAviabilet> data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public IEnumerable<ZayavkaNaAviabilet> Load()
        {
            if (!File.Exists(_filePath)) return new List<ZayavkaNaAviabilet>();
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<ZayavkaNaAviabilet>>(json);
        }
    }
}