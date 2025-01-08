using AutoMapper;
using PubAPI.DTOs;
using PublisherDomain;

namespace PubAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<AuthorDTO, Author>()
            //    .ForMember(dest => dest.Books, opt => opt.Ignore());

            CreateMap<AuthorDTOCreate, Author>()
                .ForMember(dest => dest.AuthorId, opt => opt.Ignore())
                .ForMember(dest => dest.Books, opt => opt.Ignore());

            //CreateMap<AuthorWithBooksDTO, Author>();

            CreateMap<Author, AuthorWithBooksDTO>();

            CreateMap<Author, AuthorDTO>();

            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId));

        }
    }
}
