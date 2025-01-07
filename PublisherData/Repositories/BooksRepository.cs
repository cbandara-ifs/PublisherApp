using Microsoft.EntityFrameworkCore;
using PublisherData.Repositories.Interfaces;
using PublisherDomain;

namespace PublisherData.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly PubContext _dbContext;

        public BooksRepository(PubContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _dbContext.Books.FindAsync(id); 
        }

        public bool BookExist(int id)
        {
            return _dbContext.Books.Any(book => book.BookId == id);
        }

        public async Task CreateBookAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateBookAsync(Book book)
        {
            var dbEntry = _dbContext.Entry(book);
            dbEntry.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Book> GetBooksByAuthor(Author author)
        {
            return _dbContext.Books
                        .Include(book => book.Author)
                        .AsNoTracking();
        }
    }
}
