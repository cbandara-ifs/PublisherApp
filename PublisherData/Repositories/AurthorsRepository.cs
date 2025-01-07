using Microsoft.EntityFrameworkCore;
using PublisherData.Repositories.Interfaces;
using PublisherDomain;

namespace PublisherData.Repositories
{
    public class AurthorsRepository : IAurthorsRepository
    {
        private readonly PubContext _dbContext;

        public AurthorsRepository(PubContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AuthorExist(int id)
        {
            return _dbContext.Authors.Any(e => e.AuthorId == id);
        }

        public async Task CreateAurthorAsync(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAurthorAsync(Author author)
        {
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            return author;
        }

        public async Task UpdateAurthorAsync(Author author)
        {
            var dbEntry = _dbContext.Entry(author);
            dbEntry.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
