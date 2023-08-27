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
    public class LocationService_Tests
    {
        private LocationService? SubjectUnderTest { get; set; }
        private Mock<IRequestService>? RequestServiceMock { get; set; }

        private const string location_doesnt_exist = @"{'error': 'Location not found'}";
        private const string id_doesnt_exist = @"{'error': Hey! you must provide an id'}";
        private const string page_doesnt_exist = @"{'error': There is nothing here'}";

        [Theory]
        [InlineData(1200)]
        [InlineData(1700)]
        public async Task GetLocation_WhenIdHigherThatValidCharacters_ShouldReturnErrorResponse(int id)
        {
            RequestServiceMock = new Mock<IRequestService>();
            RequestServiceMock.Setup(a => a.Get($"https://rickandmortyapi.com/api/location/{id}")).ReturnsAsync(location_doesnt_exist);
            SubjectUnderTest = new LocationService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetItem(id);
            Assert.False(response.IsSuccessful);
            Assert.Same("location_not_found", response.error);
        }

        [Theory]
        [InlineData(12)]
        [InlineData(17)]
        public async Task GetLocation_WhenIdIsValid_ShouldReturnValidResponse(int id)
        {
            SubjectUnderTest = new LocationService(new RequestService());
            var response = await SubjectUnderTest.GetItem(id);
            Assert.True(response.IsSuccessful);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        public async Task GetLocations_WhenPageIsInvalid_ShouldReturnErrorResponse(int id)
        {
            RequestServiceMock = new Mock<IRequestService>();
            SubjectUnderTest = new LocationService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetItem(id);
            Assert.False(response.IsSuccessful);
            Assert.Same("invalid_id", response.error);
        }

        [Theory]
        [InlineData(3000)]
        [InlineData(2000)]
        public async Task GetLocations_WhenPageIsLargerThanCount_ShouldReturnErrorResponse(int page)
        {
            RequestServiceMock = new Mock<IRequestService>();
            RequestServiceMock.Setup(a => a.Get($"https://rickandmortyapi.com/api/location?page={page}")).ReturnsAsync(page_doesnt_exist);
            SubjectUnderTest = new LocationService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetAll(page);
            Assert.False(response.IsSuccessful);
            Assert.Same("invalid_page", response.error);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public async Task GetLocations_WhenPageIsValid_ShouldReturnValidResponse(int page)
        {
            SubjectUnderTest = new LocationService(new RequestService());
            var response = await SubjectUnderTest.GetAll(page);
            Assert.True(response.IsSuccessful);
            Assert.Null(response.error);
        }

        [Fact]
        public async Task GetLocationsByIds_WhenIdsAreNull_ShouldReturnErrorResponse()
        {
            RequestServiceMock = new Mock<IRequestService>();
            SubjectUnderTest = new LocationService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetItems(null);
            Assert.Empty(response);
        }

        [Fact]
        public async Task GetLocationsByIds_WhenIdsIsAnEmptyList_ShouldReturnErrorResponse()
        {
            RequestServiceMock = new Mock<IRequestService>();
            SubjectUnderTest = new LocationService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetItems(new List<int>());
            Assert.Empty(response);
        }

        [Fact]
        public async Task GetLocationsByIds_WhenIdsAreLargerThatCount_ShouldReturnErrorResponse()
        {
            RequestServiceMock = new Mock<IRequestService>();
            SubjectUnderTest = new LocationService(RequestServiceMock.Object);
            var response = await SubjectUnderTest.GetItems(new List<int>());
            Assert.Empty(response);
        }

        [Fact]
        public async Task GetLocationsByIds_WhenIdsAreValid_ShouldReturnValidResponse()
        {
            SubjectUnderTest = new LocationService(new RequestService());
            var response = await SubjectUnderTest.GetItems(new List<int>() { 12, 14, 15, 16 });
            Assert.NotEmpty(response);
            Assert.True(response.Count > 0);
        }
    }

}
