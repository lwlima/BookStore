namespace BookStore.Domain
{
    public class Category
    {
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            this.Books = new List<Book>();
        }
        public Category()
        {
            this.Books = new List<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
