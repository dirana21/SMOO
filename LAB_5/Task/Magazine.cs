namespace LAB_5
{
    public class Magazine
    {
        private string? title;
        private Frequency? frequency;
        private DateTime? dateRelease;
        private int? edition;
        private Article[]? article;

        public Magazine(string title, Frequency frequency, DateTime dateRelease, int edition)
        {
            this.title = title;
            this.frequency = frequency;
            this.dateRelease = dateRelease;
            this.edition = edition;
            this.article = new Article[10];
        }

        public Magazine()
        {
            this.title = null;
            this.frequency = new Frequency();
            this.dateRelease = DateTime.Now;
            this.edition = null;
            this.article = new Article[10];
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
            return $"Title: {title}, Frequency: {frequency}, DateRelease: {dateRelease}, Edition: {edition}, Articles:\\n{articlesStr}";
        }

        public string ToShortString()
        {
            double sum = 0;
            int count = 0;
            if (article != null)
            {
                foreach (var art in article)
                {
                    if (art != null)
                    {
                        sum += art.rating ?? 0;
                        count++;
                    }
                }
            }
            double? averageRating = count > 0 ? sum / count : null;
            return $"Title: {title}, Frequency: {frequency}, DateRelease: {dateRelease}, AverageRating: {averageRating}";
        }
        
        public Frequency? Frequency { get => frequency; set => frequency = value; }
        public DateTime? DateRelease { get => dateRelease; set => dateRelease = value; }
        public int? Edition { get => edition; set => edition = value; }
        public Article[]? Article { get => article; set => article = value; }
        public string? Title { get => title; set => title = value; }

        public double? AverageRating()
        {
            double sum = 0;
            int count = 0;
            if (article != null)
            {
                foreach (var art in article)
                {
                    if (art != null)
                    {
                        sum += art.rating ?? 0;
                        count++;
                    }
                }
            }
            double? averageRating = count > 0 ? sum / count : null;
            return averageRating;
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

            // Найдём первое свободное место
            for (int i = 0; i < article.Length && index < articles.Length; i++)
            {
                if (article[i] == null)
                {
                    article[i] = articles[index];
                    index++;
                }
            }

            // Если не все статьи влезли
            if (index < articles.Length)
            {
                Console.WriteLine("Не все статьи были добавлены: недостаточно места в массиве.");
            }
        }
    }
}

