namespace Task1
{
    public class Article : IComparable<Article>, ICloneable
    {
        public Person author { get; set; }
        public string title { get; set; }
        public double rating { get; set; }

        public Article(Person author, string title, double rating)
        {
            this.author = author;
            this.title = title;
            this.rating = rating;
        }

        public Article()
        {
            this.author = new Person();
            this.title = "";
            this.rating = 0;
        }

        public override string ToString()
        {
            return $" Title: {this.title}\n Author: {this.author}\n Rating: {this.rating}";
        }

        public object Clone()
        {
            return new Article((Person)this.author.Clone(), this.title, this.rating);
        }
        
        public int CompareTo(Article? other)
        {
            if (other == null) return 1;
            return rating.CompareTo(other.rating);
        }
    }
}