using AutoMapper;
using PubAPI.DTOs;
using PubAPI.Services.Interfaces;
using PublisherData.Repositories.Interfaces;
using PublisherDomain;

namespace PubAPI.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAurthorsRepository _aurthorsRepository;
        private readonly IMapper _mapper;

        public AuthorsService(IAurthorsRepository aurthorsRepository, IMapper mapper)
        {
            _aurthorsRepository = aurthorsRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDTO?> GetAuthorByIdAsync(int id)
        {
            var author = await _aurthorsRepository.GetByIdAsync(id);
            if (author == null)
            {
                return null;
            }
            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task<IEnumerable<AuthorDTO>> GetAuthorsAsync()
        {
            var authorList = await _aurthorsRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AuthorDTO>>(authorList);
        }

        public async Task<AuthorWithBooksDTO?> GetAuthorByIdWithBooksAsync(int id)
        {
            var author = await _aurthorsRepository.GetByIdWithBooksAsync(id);

            return _mapper?.Map<AuthorWithBooksDTO>(author);
        }

        public IEnumerable<AuthorWithBooksDTO> GetAuthorsWithBooksAsync()
        {
            var authorsWithBookList = _aurthorsRepository
                .GetAllWithBooks()
                .AsEnumerable();

            return _mapper.Map<IEnumerable<AuthorWithBooksDTO>>(authorsWithBookList);
        }

        public async Task UpdateAuthorAsync(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            await _aurthorsRepository.UpdateAurthorAsync(author);
        }

        public bool AuthorExist(int id)
        {
            return _aurthorsRepository.AuthorExist(id);
        }

        public async Task CreateAurthorAsync(AuthorDTOCreate authorDTOCreate)
        {
            var author = _mapper.Map<Author>(authorDTOCreate);
            await _aurthorsRepository.CreateAurthorAsync(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _aurthorsRepository.GetByIdAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }

            await _aurthorsRepository.DeleteAurthorAsync(author);
        }
    }
}
