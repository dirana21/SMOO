using Newtonsoft.Json;

namespace Task3
{
    public class JsonSongSerializer : ISongSerializer
    {
        public string Serialize(List<Song> songs)
        {
            return JsonConvert.SerializeObject(songs, Formatting.Indented);
        }

        public List<Song> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<List<Song>>(json) ?? new List<Song>();
        }
    }
}