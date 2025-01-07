using Microsoft.EntityFrameworkCore;
using PublisherData.Repositories;
using PublisherDomain;

namespace PublisherData.Test
{
    public class AuthorsRepositoryTests
    {
        private readonly DbContextOptionsBuilder<PubContext> _builder;

        public AuthorsRepositoryTests()
        {
            _builder = new DbContextOptionsBuilder<PubContext>();
        }

        //[Fact]
        public void CanInsertAuthorIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<PubContext>();
            // changging to in memory provider
            // builder.UseSqlServer("Server=CHIBS\\SQLEXPRESS;Database=PubDatabase;User Id=sa;Password=Sword123;");
            builder.UseInMemoryDatabase("CanInsertAuthorIntoDatabase");

            using (var context = new PubContext(builder.Options))
            {
                // changging to in memory provider
                // context.Database.EnsureDeleted();
                // context.Database.EnsureCreated();

                var author = new Author { FirstName = "a", LastName = "b" };
                context.Authors.Add(author);

                // changging to in memory provider
                //Debug.WriteLine($"Before save: {author.AuthorId}");
                //context.SaveChanges();
                //Debug.WriteLine($"After save: {author.AuthorId}");
                //Assert.NotEqual(0, author.AuthorId);

                Assert.Equal(EntityState.Added, context.Entry(author).State);
            }
        }

        [Fact]
        public async Task GetByIdAsync_ValidId_ReturnsAuthor()
        {
            _builder.UseInMemoryDatabase("GetByIdAsync_ValidId_ReturnsAuthor");
            int seededId = SeedOneAuthor(_builder.Options);

            using (var context = new PubContext(_builder.Options))
            {
                var _sut = new AurthorsRepository(context);
                var actualAuthor = await _sut.GetByIdAsync(seededId);
                Assert.Equal(seededId, actualAuthor.AuthorId);
            }
        }

        [Fact]
        public async Task CreateAurthorAsync_NewAuthor_SuccesfullSave()
        {
            _builder.UseInMemoryDatabase("CreateAurthorAsync_NewAuthor_SuccesfullSave");

            using (var context = new PubContext(_builder.Options))
            {
                var _sut = new AurthorsRepository(context);
                await _sut.CreateAurthorAsync(new Author { FirstName = "a", LastName = "b" });

                var savedAuthor = await context.Authors
                                       .FirstAsync(a => a.AuthorId == 1);

                Assert.Equal(savedAuthor.FirstName, "a");
            }
        }

        private int SeedOneAuthor(DbContextOptions<PubContext> options)
        {
            using (var seedContext = new PubContext(options))
            {
                var author = new Author { FirstName = "a", LastName = "b" };
                seedContext.Authors.Add(author);
                seedContext.SaveChanges();
                return author.AuthorId;
            }
        }
    }
}