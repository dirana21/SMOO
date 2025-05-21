namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serializer = new JsonSongSerializer();
            var repository = new FileSongRepository("songs.json", serializer);

            var songs = repository.Load();
            var manager = new SongManager(songs);

            
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a song");
                Console.WriteLine("2. Delete the song");
                Console.WriteLine("3. Edit the song");
                Console.WriteLine("4. Search by performer");
                Console.WriteLine("5. Show all songs");
                Console.WriteLine("6. Save the song");
                Console.WriteLine("7. Load the song");
                Console.WriteLine("0. Exite");

                Console.Write("Choice: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var song = CreateSongFromInput();
                        manager.Add(song);
                        repository.AddSong(song);
                        repository.Save(manager.GetAll());
                        Console.WriteLine("The song has been added.");
                        break;

                    case "2":
                        Console.Write("Enter the name of the song to delete: ");
                        var toRemove = Console.ReadLine();
                        manager.Remove(toRemove!);
                        Console.WriteLine("The song has been removed.");
                        break;

                    case "3":
                        Console.Write("Enter the name of the song to edit: ");
                        var toEdit = Console.ReadLine();
                        var existing = manager.FindByName(toEdit!);
                        if (existing == null)
                        {
                            Console.WriteLine("Song not found.");
                            break;
                        }
                        var edited = CreateSongFromInput();
                        manager.Update(toEdit!, edited);
                        Console.WriteLine("The song has been updated.");
                        break;

                    case "4":
                        Console.Write("Enter artist name: ");
                        var performer = Console.ReadLine();
                        var results = manager.SearchByPerformer(performer!);
                        foreach (var s in results)
                            Console.WriteLine(s);
                        break;

                    case "5":
                        foreach (var s in manager.GetAll())
                            Console.WriteLine(s);
                        break;

                    case "6":
                        repository.Save(manager.GetAll());
                        Console.WriteLine("Saved.");
                        break;

                    case "7":
                        songs = repository.Load();
                        manager = new SongManager(songs);
                        Console.WriteLine("Loaded.");
                        break;

                    case "0":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }

            static Song CreateSongFromInput()
            {
                Console.Write("Song title: ");
                string name = Console.ReadLine()!;
                Console.Write("Author of the text: ");
                string author = Console.ReadLine()!;
                Console.Write("Composer: ");
                string composer = Console.ReadLine()!;
                Console.Write("Year: ");
                int year = int.Parse(Console.ReadLine()!);
                Console.Write("Lyrics: ");
                string text = Console.ReadLine()!;
                Console.Write("Performers (separated by commas): ");
                List<string> performers = Console.ReadLine()!
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim()).ToList();

                return new Song
                {
                    NameSong = name,
                    NameAuthor = author,
                    Composer = composer,
                    Year = year,
                    TextSong = text,
                    Performers = performers
                };
            }
        }
    }
}