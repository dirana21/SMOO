namespace Task3
{
    public class SongManager
    {
        private readonly List<Song> _songs;

        public SongManager(List<Song> initialSongs)
        {
            _songs = initialSongs;
        }

        public void Add(Song song) => _songs.Add(song);

        public void Remove(string name) =>
            _songs.RemoveAll(s => s.NameSong.Equals(name, StringComparison.OrdinalIgnoreCase));

        public void Update(string name, Song newSong)
        {
            var index = _songs.FindIndex(s => s.NameSong.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (index != -1) _songs[index] = newSong;
        }

        public List<Song> SearchByPerformer(string performer) =>
            _songs.Where(s => s.Performers.Contains(performer)).ToList();

        public List<Song> GetAll() => _songs;
        
        public Song? FindByName(string name)
        {
            return _songs.FirstOrDefault(s => s.NameSong.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}