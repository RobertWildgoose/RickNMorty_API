using ApiUtilities.Common.Interfaces;
using ApiUtilities.Common.Models;
using Moq;
using Newtonsoft.Json;
using RickNMorty.Common.Models.Common;
using RickNMorty.Common.Models.Episodes;
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
	public class EpisodeServiceTests
	{
		private readonly Mock<IHttpClientService> _httpClientServiceMock;
		private readonly Mock<IBaseConfiguration> _baseConfigMock;
		private readonly EpisodeService _episodeService;

		public EpisodeServiceTests()
		{
			_httpClientServiceMock = new Mock<IHttpClientService>();
			_baseConfigMock = new Mock<IBaseConfiguration>();

			_baseConfigMock.SetupGet(c => c.BaseUrl).Returns("https://example.com");
			_baseConfigMock.SetupGet(c => c.TimeoutSeconds).Returns(30);

			_episodeService = new EpisodeService(_httpClientServiceMock.Object, _baseConfigMock.Object);
		}

		[Fact]
		public async Task GetAllEpisodes_SuccessfulRequest_ReturnsEpisodeResponse()
		{
			// Arrange
			var expectedResponse = new EpisodeResponse
			{
				Info = new ResponseInfo { Count = 3, Pages = 1, Next = null, Previous = null },
				Results = new List<Episode>
			{
				new Episode { Id = 1, Name = "Episode 1", Success = true },
				new Episode { Id = 2, Name = "Episode 2", Success = true },
				new Episode { Id = 3, Name = "Episode 3", Success = true }
			}
			};
			var responseContainer = new ResponseContainer<EpisodeResponse>
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
			var result = await _episodeService.GetAllEpisodes(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedResponse.Info.Count, result.Info.Count);
			Assert.Equal(expectedResponse.Results.Count, result.Results.Count);
		}

		[Fact]
		public async Task GetEpisode_SuccessfulRequest_ReturnsEpisode()
		{
			// Arrange
			var expectedEpisode = new Episode { Id = 1, Name = "Test Episode", Success = true };
			var responseContainer = new ResponseContainer<Episode>
			{
				Data = expectedEpisode
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
			var result = await _episodeService.GetEpisode(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedEpisode.Id, result.Id);
			Assert.Equal(expectedEpisode.Name, result.Name);
		}

		[Fact]
		public async Task GetEpisodes_ByIdList_SuccessfulRequest_ReturnsEpisodesList()
		{
			// Arrange
			var episodeIds = new List<int> { 1, 2, 3 };
			var expectedEpisodes = new List<Episode>
		{
			new Episode { Id = 1, Name = "Episode 1", Success = true },
			new Episode { Id = 2, Name = "Episode 2", Success = true },
			new Episode { Id = 3, Name = "Episode 3", Success = true }
		};

			foreach (var episode in expectedEpisodes)
			{
				var responseContainer = new ResponseContainer<Episode>
				{
					Data = episode
				};
				var jsonResponse = JsonConvert.SerializeObject(responseContainer.Data);

				var httpResponseMessage = new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
				};

				_httpClientServiceMock.Setup(s => s.GetAsync($"https://example.com/episode/{episode.Id}", It.IsAny<CancellationToken>()))
					.ReturnsAsync(httpResponseMessage);
			}

			// Act
			var result = await _episodeService.GetEpisodes(episodeIds);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedEpisodes.Count, result.Count);
			for (int i = 0; i < expectedEpisodes.Count; i++)
			{
				Assert.Equal(expectedEpisodes[i].Id, result[i].Id);
				Assert.Equal(expectedEpisodes[i].Name, result[i].Name);
			}
		}

		[Fact]
		public async Task GetEpisodes_ByIdList_EmptyList_ReturnsEmptyList()
		{
			// Act
			var result = await _episodeService.GetEpisodes(new List<int>());

			// Assert
			Assert.NotNull(result);
			Assert.Empty(result);
		}
	}
}