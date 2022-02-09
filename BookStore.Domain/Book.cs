namespace BookStore.Domain
{
    public class Book
    {
        public Book(int id, string title, string isbn, decimal price, string author, DateTime releaseDate, int categoryId)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
            Price = price;
            Author = author;
            ReleaseDate = releaseDate.Date;
            CategoryId = categoryId;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
