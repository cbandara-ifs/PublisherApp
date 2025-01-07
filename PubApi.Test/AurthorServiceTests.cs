using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Moq;
using PubAPI.DTOs;
using PubAPI.Services;
using PublisherData.Repositories.Interfaces;
using PublisherDomain;

namespace PubApi.Test
{
    public class AurthorServiceTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IAurthorsRepository> _mockAuthorRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AuthorsService _sut;

        public AurthorServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _mockAuthorRepository = _fixture.Freeze<Mock<IAurthorsRepository>>();
            _mockMapper = _fixture.Freeze<Mock<IMapper>>();
            _sut = _fixture.Build<AuthorsService>().OmitAutoProperties().Create();
        }

        [Fact]
        public async Task GetAuthorByIdAsync_ValidId_ReturnAurthorDTO()
        {
            var aurthor = _fixture.Build<Author>()
                                    .WithAutoProperties()
                                    .With(opt => opt.AuthorId, 1)
                                    .OmitAutoProperties() // stopping circular references
                                    .Create();

            var authorDTO = _fixture.Build<AuthorDTO>()
                                    .WithAutoProperties()
                                    .With(opt => opt.AuthorId, 1)
                                    .Create();

            _mockAuthorRepository.Setup(method => 
                                    method.GetByIdAsync(It.IsAny<int>()))
                                    .ReturnsAsync(aurthor);

            _mockMapper.Setup(method =>
                            method.Map<AuthorDTO>(It.IsAny<Author>()))
                            .Returns(authorDTO);

            var result = await _sut.GetAuthorByIdAsync(1);

            Assert.True(aurthor.AuthorId == result.AuthorId);
        }
    }
}