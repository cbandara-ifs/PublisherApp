using PubAPI.DTOs;

namespace PubAPI.Services.Interfaces
{
    public interface IBooksService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync();

        Task<BookDTO?> GetBookByIDAsync(int id);
    }
}
