using BookStore.Domain.Contracts;

namespace BookStore.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Book { get; }
        ICategoryRepository Category { get; }

        Task CompleteAsync();
    }
}
