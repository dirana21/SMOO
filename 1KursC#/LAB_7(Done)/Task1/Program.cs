namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = new GenericContainer<int>();
            container.Add(12);
            container.Add(2);
            container.Add(9);

            foreach (var item in container)
            {
                Console.WriteLine(item);
            }

            container.Sort();

            Console.WriteLine("After sorting:");
            foreach (var item in container)
            {
                Console.WriteLine(item);
            }

            container.Save("data.txt");
            var copy = container.CopyFirst(2);
            copy.Save("copy.txt");
        }
    }
}

