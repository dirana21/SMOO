namespace Task3
{
    public class Song
    {
        public string NameSong { get; set; }
        public string NameAuthor { get; set; }
        public string Composer { get; set; }
        public int Year { get; set; }
        public string TextSong { get; set; }
        public List<string> Performers { get; set; } = new();

        public override string ToString()
        {
            return $"Song: {NameSong}, Author: {NameAuthor}, Composer: {Composer}, Year: {Year}";
        }
    }
}