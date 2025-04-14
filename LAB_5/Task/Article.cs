namespace LAB_5
{
    public class Article
    {
        public Person? author { get; set; }
        public string? title { get; set; }
        public double? rating { get; set; }

        public Article(Person author, string title, double rating)
        {
            this.author = author;
            this.title = title;
            this.rating = rating;
        }

        public Article()
        {
            this.author = new Person();
            this.title = null;
            this.rating = 0;
        }

        public override string ToString()
        {
            return $"Title: {this.title}, Author: {this.author}, Rating: {this.rating}";
        }
    }
}

