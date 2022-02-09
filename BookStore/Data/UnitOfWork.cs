using BookStore.Context;
using BookStore.Domain.Contracts;
using BookStore.Data.Repositories;

namespace BookStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private readonly DBContext _context;

        public IBookRepository Book { get; set;  }
        public ICategoryRepository Category { get; set; }

        public UnitOfWork(DBContext context)
        {
            _context = context;
            Book = new BookRepository(context);
            Category = new CategoryRepository(context);
        }


        async Task IUnitOfWork.CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
