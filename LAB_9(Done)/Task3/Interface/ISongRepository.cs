namespace Task3
{
    public interface ISongRepository
    {
        void Save(List<Song> songs);
        void AddSong(Song song);
        List<Song> Load();
    }
}