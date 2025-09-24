namespace Task3
{
    public class FileSongRepository : ISongRepository
    {
        private readonly string _filePath;
        private readonly ISongSerializer _serializer;

        public FileSongRepository(string filePath, ISongSerializer serializer)
        {
            _filePath = filePath;
            _serializer = serializer;
        }

        public List<Song> Load()
        {
            Console.WriteLine($"Loading songs from: {_filePath}");
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("File not found, returning empty list.");
                return new List<Song>();
            }

            string json = File.ReadAllText(_filePath);
            Console.WriteLine($"Loaded json length: {json.Length}");
            var songs = _serializer.Deserialize(json);
            Console.WriteLine($"Loaded {songs.Count} songs.");
            return songs;
        }

        public void Save(List<Song> songs)
        {
            Console.WriteLine($"Saving {songs.Count} songs to: {_filePath}");
            string json = _serializer.Serialize(songs);
            File.WriteAllText(_filePath, json);
            Console.WriteLine("Save completed.");
        }

        public void AddSong(Song song)
        {
            Console.WriteLine($"Adding song: {song.NameSong}");
            var songs = Load();
            songs.Add(song);
            Save(songs);
            Console.WriteLine("AddSong completed.");
        }
    }
}