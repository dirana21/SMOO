namespace Task3
{
    public interface ISongSerializer
    {
        string Serialize(List<Song> songs);
        List<Song> Deserialize(string json);
    }
}