using Moq;
using RickNMorty_API_Wrapper.Services.Implementations;
using RickNMorty_API_Wrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Tests.Services
{
    public class CharacterService_Tests
    {
        private CharacterService? SubjectUnderTest { get; set; }
        private Mock<IRequestService>? RequestServiceMock { get; set; }

        private const string character_doesnt_exist = @"{'error': 'Character not found'}";
        private const string id_doesnt_exist = @"{'error': Hey! you must provide an id'}";
        private const string page_doesnt_exist = @"{'error': There is nothing here'}";

        [Theory]
        [InlineData(1200)]
        [InlineData(1700)]
        public async Task GetCharacter_WhenIdHigherThatValidCharacters_ShouldReturnErrorResponse(int id)
        {
            RequestServiceMock = new Mock<IRequestService>();
            RequestServiceMock.Setup(a => a.Get($"https://rickandmortyapi.com/api/character/{id}")).ReturnsAsync(character_doesnt_exist);
            SubjectUnderTest = new CharacterService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetItem(id);
            Assert.False(response.IsSuccessful);
            Assert.Same("character_not_found", response.error);
        }

        [Theory]
        [InlineData(12)]
        [InlineData(17)]
        public async Task GetCharacter_WhenIdIsValid_ShouldReturnValidResponse(int id)
        {
            SubjectUnderTest = new CharacterService(new RequestService());
            var response = await SubjectUnderTest.GetItem(id);
            Assert.True(response.IsSuccessful);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        public async Task GetCharacters_WhenPageIsInvalid_ShouldReturnErrorResponse(int id)
        {
            RequestServiceMock = new Mock<IRequestService>();
            SubjectUnderTest = new CharacterService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetItem(id);
            Assert.False(response.IsSuccessful);
            Assert.Same("invalid_id", response.error);
        }

        [Theory]
        [InlineData(3000)]
        [InlineData(2000)]
        public async Task GetCharacters_WhenPageIsLargerThanCount_ShouldReturnErrorResponse(int page)
        {
            RequestServiceMock = new Mock<IRequestService>();
            RequestServiceMock.Setup(a => a.Get($"https://rickandmortyapi.com/api/character?page={page}")).ReturnsAsync(page_doesnt_exist);
            SubjectUnderTest = new CharacterService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetAll(page);
            Assert.False(response.IsSuccessful);
            Assert.Same("invalid_page", response.error);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public async Task GetCharacters_WhenPageIsValid_ShouldReturnValidResponse(int page)
        {
            SubjectUnderTest = new CharacterService(new RequestService());
            var response = await SubjectUnderTest.GetItem(page);
            Assert.True(response.IsSuccessful);
            Assert.Null(response.error);
        }

        [Fact]
        public async Task GetCharactersByIds_WhenIdsAreNull_ShouldReturnErrorResponse()
        {
            RequestServiceMock = new Mock<IRequestService>();
            SubjectUnderTest = new CharacterService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetItems(null);
            Assert.Empty(response);
        }

        [Fact]
        public async Task GetCharactersByIds_WhenIdsIsAnEmptyList_ShouldReturnErrorResponse()
        {
            RequestServiceMock = new Mock<IRequestService>();
            SubjectUnderTest = new CharacterService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetItems(new List<int>());
            Assert.Empty(response);
        }

        [Fact]
        public async Task GetCharactersByIds_WhenIdsAreLargerThatCount_ShouldReturnErrorResponse()
        {
            RequestServiceMock = new Mock<IRequestService>();
            SubjectUnderTest = new CharacterService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetItems(new List<int>());
            Assert.Empty(response);
        }

        [Fact]
        public async Task GetCharactersByIds_WhenIdsAreValid_ShouldReturnValidResponse()
        {
            SubjectUnderTest = new CharacterService(new RequestService());
            var response = await SubjectUnderTest.GetItems(new List<int>() { 12,14,15,16});
            Assert.NotEmpty(response);
            Assert.True(response.Count > 0);
        }
    }
}