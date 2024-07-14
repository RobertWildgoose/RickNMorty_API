using ApiUtilities.Common.Interfaces;
using ApiUtilities.Common.Models;
using Moq;
using Newtonsoft.Json;
using RickNMorty.Common.Models.Common;
using RickNMorty.Common.Models.Locations;
using RickNMorty.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RickNMorty.Tests.Services
{
	public class LocationServiceTests
	{
		private readonly Mock<IHttpClientService> _httpClientServiceMock;
		private readonly Mock<IBaseConfiguration> _baseConfigMock;
		private readonly LocationService _locationService;

		public LocationServiceTests()
		{
			_httpClientServiceMock = new Mock<IHttpClientService>();
			_baseConfigMock = new Mock<IBaseConfiguration>();

			_baseConfigMock.SetupGet(c => c.BaseUrl).Returns("https://example.com");
			_baseConfigMock.SetupGet(c => c.TimeoutSeconds).Returns(30);

			_locationService = new LocationService(_httpClientServiceMock.Object, _baseConfigMock.Object);
		}

		[Fact]
		public async Task GetLocation_SuccessfulRequest_ReturnsLocation()
		{
			// Arrange
			var expectedLocation = new Location { Id = 1, Name = "Test Location" , Success = true};
			var responseContainer = new ResponseContainer<Location>
			{
				Data = expectedLocation
			};
			var jsonResponse = JsonConvert.SerializeObject(responseContainer.Data);

			var httpResponseMessage = new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.OK,
				Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
			};

			_httpClientServiceMock.Setup(s => s.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(httpResponseMessage);

			// Act
			var result = await _locationService.GetLocation(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedLocation.Id, result.Id);
			Assert.Equal(expectedLocation.Name, result.Name);
		}

		[Fact]
		public async Task GetLocations_ByIdList_SuccessfulRequest_ReturnsLocationsList()
		{
			// Arrange
			var locationIds = new List<int> { 1, 2, 3 };
			var expectedLocations = new List<Location>
			{
				new Location { Id = 1, Name = "Location 1" , Success = true},
				new Location { Id = 2, Name = "Location 2" , Success = true},
				new Location { Id = 3, Name = "Location 3" , Success = true}
			};

			foreach (var location in expectedLocations)
			{
				var responseContainer = new ResponseContainer<Location>
				{
					Data = location
				};
				var jsonResponse = JsonConvert.SerializeObject(responseContainer.Data);

				var httpResponseMessage = new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
				};

				_httpClientServiceMock.Setup(s => s.GetAsync($"https://example.com/location/{location.Id}", It.IsAny<CancellationToken>()))
					.ReturnsAsync(httpResponseMessage);
			}

			// Act
			var result = await _locationService.GetLocations(locationIds);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedLocations.Count, result.Count);
			for (int i = 0; i < expectedLocations.Count; i++)
			{
				Assert.Equal(expectedLocations[i].Id, result[i].Id);
				Assert.Equal(expectedLocations[i].Name, result[i].Name);
			}
		}

		[Fact]
		public async Task GetLocations_ByIdList_EmptyList_ReturnsEmptyList()
		{
			// Act
			var result = await _locationService.GetLocations(new List<int>());

			// Assert
			Assert.NotNull(result);
			Assert.Empty(result);
		}

		[Fact]
		public async Task GetLocations_ByPage_SuccessfulRequest_ReturnsLocationResponse()
		{
			// Arrange
			var expectedResponse = new LocationResponse
			{
				Info = new ResponseInfo { Count = 3, Pages = 1, Next = null, Previous = null },
				Results = new List<Location>
			{
				new Location { Id = 1, Name = "Location 1" , Success = true},
				new Location { Id = 2, Name = "Location 2" , Success = true},
				new Location { Id = 3, Name = "Location 3" , Success = true}
			}
			};
			var responseContainer = new ResponseContainer<LocationResponse>
			{
				Data = expectedResponse
			};
			var jsonResponse = JsonConvert.SerializeObject(responseContainer.Data);

			var httpResponseMessage = new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.OK,
				Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
			};

			_httpClientServiceMock.Setup(s => s.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(httpResponseMessage);

			// Act
			var result = await _locationService.GetLocations(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedResponse.Info.Count, result.Info.Count);
			Assert.Equal(expectedResponse.Results.Count, result.Results.Count);
		}

	}
}
