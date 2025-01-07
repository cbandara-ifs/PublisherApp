using Microsoft.AspNetCore.Mvc;
using PubAPI.DTOs;
using PubAPI.Services.Interfaces;

namespace PubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _bookService;

        public BooksController(IBooksService booksService)
        {
            _bookService = booksService;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDTO>> GetBooks()
        {
            return await _bookService.GetBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO?>> GetBook(int id)
        {
            return await _bookService.GetBookByIDAsync(id);
        }
    }
}
