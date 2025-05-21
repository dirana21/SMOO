namespace Task2
{
    
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Select a text file:");
            string textPath = FileManager.INSTANCE.OpenFile();
            Console.WriteLine("File selected: " + textPath);

            Console.WriteLine("Select a file with words to censor:");
            string censorePath = FileManager.INSTANCE.OpenFile();
            Console.WriteLine("File selected: " + censorePath);

            Console.WriteLine("\nChoose a location to save the result:");
            string outputPath = FileManager.INSTANCE.SaveFile();
            var reader = new FileTextReader();
            var writer = new FileTextWriter();
            var censorship = new SimpleCensore();

            var processor = new CensoreManager(reader, writer, censorship);
            processor.Run(textPath, censorePath, outputPath);

            Console.WriteLine("The file was successfully processed.");
            Console.WriteLine("The result will be saved in: " + outputPath);
        }
    }
}

