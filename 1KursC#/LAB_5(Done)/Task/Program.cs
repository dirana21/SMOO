namespace LAB_5
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Magazine mag = new Magazine();
            Console.WriteLine("\tShort information about magazine:");
            Console.WriteLine(mag.ToShortString());
            Console.WriteLine();

            
            
            Console.WriteLine($"\tIndex of Frequency:\n Weekly: {mag[Frequency.Weekly]}\n Monthly: {mag[Frequency.Monthly]}\n Yearly: {mag[Frequency.Yearly]}");
            Console.WriteLine();
            
            mag.Title = " Sience and life";
            mag.Frequency = Frequency.Monthly;
            mag.DateRelease = new DateTime(2024, 4, 10);
            mag.Edition = 10000;
            mag.Article = new Article[5];

            Console.WriteLine("\tFull information about Magazine:");
            Console.WriteLine(mag.ToString());
            Console.WriteLine();
            
            Article art1 = new Article(new Person("Ivan", "Ivanenk", new DateTime(1980, 3, 15)), "Machine learning", 9.0);
            Article art2 = new Article(new Person("Oksana", "Petrenko", new DateTime(1990, 5, 10)), "Quantum computing", 8.5);
            Article art3 = new Article(new Person("Andriy", "Shevchenko", new DateTime(1985, 8, 22)), "History of Sience", 9.3);
            mag.AddArticles(art1, art2, art3);

            Console.WriteLine("\tUpdated articles:");
            foreach (var a in mag.Article)
            {
                if (a != null)
                {
                    Console.WriteLine(a);
                    Console.WriteLine();
                }
                
            }
            
            Magazine[] magazines = new Magazine[4];

            magazines[0] = new Magazine(" Tech Today", Frequency.Weekly, new DateTime(2024, 1, 15), 5000,
                new Article[3] 
                {
                    new Article(new Person(" Maria", " Koval", new DateTime(1987, 12, 5)), "AI Revolution", 9.4),
                    new Article(null, " New algoritm", 8.7),
                    null
                });

            magazines[1] = new Magazine(" Science View", Frequency.Monthly, new DateTime(2024, 3, 20), 8000,
                new Article[4] 
                {
                    new Article(new Person(" Yuriy", " Dmitrenko", new DateTime(1975, 2, 12)), " String theory", 9.8),
                    new Article(new Person(" Irina", " Levchenko", new DateTime(1992, 7, 9)), " Space road", 9.1),
                    null, 
                    null
                });

            magazines[2] = new Magazine(" Eco Planet", Frequency.Yearly, new DateTime(2023, 11, 1), 3000,
                new Article[2] 
                {
                    new Article(new Person(" Oleg", " Gonchar", new DateTime(1980, 6, 30)), " Green energy", 8.2),
                    null
                });

            magazines[3] = mag;
            
            Console.WriteLine("\tThree best magazines:");
            var top3 = magazines.OrderByDescending(m => m.AverageRating()).Take(3);
            foreach (var m in top3)
            {
                Console.WriteLine($"{m.Title} (Average rating: {m.AverageRating():F2})");
            }
            Console.WriteLine();
            
            var mostArticles = magazines.OrderByDescending(m => m.Article != null ? m.Article.Count(a => a != null) : 0).First();

            int maxCount = mostArticles.Article != null ? mostArticles.Article.Count(a => a != null) : 0;
            Console.WriteLine("Magazine with the most articles:");
            Console.WriteLine($"{mostArticles.Title} (Number of articles: {maxCount})");
        }
    }
}

