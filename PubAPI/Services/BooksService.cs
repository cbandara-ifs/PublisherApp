using AutoMapper;
using PubAPI.DTOs;
using PubAPI.Services.Interfaces;
using PublisherData.Repositories.Interfaces;

namespace PubAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookDTO>> GetBooksAsync()
        {
            var bookList = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDTO>>(bookList);
        }

        public async Task<BookDTO?> GetBookByIDAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookDTO>(book);
        }
    }
}
