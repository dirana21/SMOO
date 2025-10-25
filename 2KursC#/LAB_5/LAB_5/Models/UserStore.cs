using LAB_5.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace LAB_5.Models
{
    public class UserStore
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _opts = new() { WriteIndented = true };
        private List<User> _users = new();

        public UserStore(string path)
        {
            _path = path;
            Load();
        }

        public IEnumerable<User> Users => _users;

        public void Load()
        {
            if (!File.Exists(_path))
            {
                _users = new List<User>();
                return;
            }
            var json = File.ReadAllText(_path);
            _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(_users, _opts);
            Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
            File.WriteAllText(_path, json);
        }

        public bool Exists(string username, string email)
            => _users.Any(u => u.Username == username || u.Email == email);

        public void Add(User u)
        {
            _users.Add(u);
            Save();
        }

        public User? FindByUsername(string username)
            => _users.FirstOrDefault(u => u.Username == username);
    }
}
