#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PubAPI.DTOs;
using PubAPI.Services.Interfaces;
using PublisherData;
using PublisherData.Repositories.Interfaces;

namespace PubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsWithBooksController : ControllerBase
    {
        private readonly PubContext _context;
        private readonly IAuthorsService _authorsService;

        public AuthorsWithBooksController(PubContext context, IAuthorsService authorsService)
        {
            _context = context;
            _authorsService = authorsService;
        }

        [HttpGet]
        public IEnumerable<AuthorWithBooksDTO> GetAuthors()
        {
            return _authorsService.GetAuthorsWithBooksAsync();
        }


        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorWithBooksDTO>> GetAuthor(int id)
        {
            var author = await _authorsService.GetAuthorByIdWithBooksAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

    }
}
