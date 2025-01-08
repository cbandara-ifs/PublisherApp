namespace PubAPI.DTOs
{
    public class AuthorWithBooksDTO
    {
        public AuthorWithBooksDTO()
        {
            Books = new List<BookDTO>();
        }
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}
