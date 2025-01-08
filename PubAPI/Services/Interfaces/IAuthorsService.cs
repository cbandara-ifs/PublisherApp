using Microsoft.AspNetCore.Mvc;
using PubAPI.DTOs;

namespace PubAPI.Services.Interfaces
{
    public interface IAuthorsService
    {
        Task<IEnumerable<AuthorDTO>> GetAuthorsAsync();

        Task<AuthorDTO?> GetAuthorByIdAsync(int id);

        IEnumerable<AuthorWithBooksDTO> GetAuthorsWithBooksAsync();

        Task<AuthorWithBooksDTO?> GetAuthorByIdWithBooksAsync(int id);

        Task UpdateAuthorAsync(AuthorDTO authorDTO);

        Task CreateAurthorAsync(AuthorDTOCreate authorDTOCreate);

        Task DeleteAuthorAsync(int id);

        bool AuthorExist(int id);
    }
}
