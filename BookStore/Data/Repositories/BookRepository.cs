using BookStore.Context;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DBContext _context;
        public BookRepository(DBContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> Create(Book book)
        {
            try
            {
                _context.Books.Add(book);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public virtual async Task<bool> Update(Book book)
        {
            try
            {
                _context.Books.Update(book);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<bool> Delete(int? id)
        {
            try
            {
                _context.Books.Remove(await _context.Books.FindAsync(id));

                return true;
            }
            catch
            {
                return false;
            }
                
        }

        public virtual async Task<Book> GetById(int? id)
        {
            return await _context.Books
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
            //_context.Books
              //  .Include(b => b.Category)
               // .FirstOrDefaultAsync(m => m.Id == id);
        }

        public virtual async Task<List<Book>> GetWithAuthor(int skip = 0, int take = 25)
        {
            return await _context.Set<Book>().OrderBy(x=>x.Title).Skip(skip).Take(take).ToListAsync();
            //return _db.Books.Include(x => x.Authors).OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public virtual async Task<Book> GetWithAuthors(int? id)
        {
            return await _context.Set<Book>().Where(x => x.Id == id).FirstOrDefaultAsync();
            // return _db.Books.Include(x => x.Authors).Where(x => x.Id == id).FirstOrDefault();
        }

        public virtual async Task<List<Book>> Get(int skip = 0, int take = 25)
        {
            return await _context.Books.Include(x => x.Category).OrderBy(x => x.Title).Skip(skip).Take(take).ToListAsync();
            //return await _context.Books.Include(x => x.Category).ToListAsync();
            //return _db.Books.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
            //var dBContext = _context.Books.Include(b => b.Category);
            //return View(await dBContext.ToListAsync());
        }
    }
}
