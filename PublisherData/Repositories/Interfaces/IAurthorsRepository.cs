using PublisherDomain;

namespace PublisherData.Repositories.Interfaces
{
    public interface IAurthorsRepository
    {
        Task<List<Author>> GetAllAsync();

        Task<Author?> GetByIdAsync(int id);

        IQueryable<Author> GetAllWithBooks();

        Task<Author?> GetByIdWithBooksAsync(int id);

        Task UpdateAurthorAsync(Author author);

        Task CreateAurthorAsync(Author author);

        Task DeleteAurthorAsync(Author author);

        bool AuthorExist(int id);
    }
}
