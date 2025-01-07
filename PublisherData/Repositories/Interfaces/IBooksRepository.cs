using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherDomain;

namespace PublisherData.Repositories.Interfaces
{
    public interface IBooksRepository
    {
        Task<List<Book>> GetAllAsync();

        Task<Book?> GetByIdAsync(int id);

        IQueryable<Book> GetBooksByAuthor(Author author);

        Task UpdateBookAsync(Book book);

        Task CreateBookAsync(Book book);

        Task DeleteBookAsync(Book book);

        bool BookExist(int id);
    }
}
