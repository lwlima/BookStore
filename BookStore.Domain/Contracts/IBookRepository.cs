namespace BookStore.Domain.Contracts
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetWithAuthor(int skip = 0, int take = 25);
        Task<Book> GetWithAuthors(int? id);
    }
}
