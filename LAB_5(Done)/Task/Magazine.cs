namespace LAB_5
{
    public class Magazine
    {
        private string? title;
        private Frequency frequency;
        private DateTime dateRelease;
        private int edition;
        private Article[]? article;

        public Magazine(string title, Frequency frequency, DateTime dateRelease, int edition, Article[]? article)
        {
            this.title = title;
            this.frequency = frequency;
            this.dateRelease = dateRelease;
            this.edition = edition;
            this.article = article;
        }

        public Magazine()
        {
            this.title = null;
            this.frequency = new Frequency();
            this.dateRelease = DateTime.Now;
            this.edition = 0;
            this.article = null;
        }

        public override string ToString()
        {
            string articlesStr = "";
            if (article != null)
            {
                foreach (var art in article)
                {
                    if (art != null) articlesStr += art.ToString() + "\n";
                }
            }
            return $" Title: {title}\n Frequency: {frequency}\n DateRelease: {dateRelease}\n Edition: {edition}\n Articles:\n{articlesStr}";
        }

        public string ToShortString()
        {

            double averageRating = AverageRating();
            return $" Title: {title}\n Frequency: {frequency}\n DateRelease: {dateRelease}\n AverageRating: {averageRating}";
        }
        
        public Frequency Frequency { get => frequency; set => frequency = value; }
        public DateTime DateRelease { get => dateRelease; set => dateRelease = value; }
        public int Edition { get => edition; set => edition = value; }
        public Article[]? Article { get => article; set => article = value; }
        public string? Title { get => title; set => title = value; }

        public double AverageRating()
        {
            if (article == null) return 0;
            double sum = 0;
            int count = 0;
            if (article != null)
            {
                foreach (var art in article)
                {
                    if (art != null)
                    {
                        sum += art.rating;
                        count++;
                    }
                }
            }
            return count > 0 ? sum / count : 0;
        }

        public bool this[Frequency frequency]
        {
            get
            {
                return this.frequency == frequency;
            }
        }

        public void AddArticles(params Article[] articles)
        {
            int index = 0;
            for (int i = 0; i < article.Length && index < articles.Length; i++)
            {
                if (article[i] == null)
                {
                    article[i] = articles[index];
                    index++;
                }
            }
            if (index < articles.Length)
            {
                Console.WriteLine("Not all articles were added: not enough space in the array.");
            }
        }
    }
}

