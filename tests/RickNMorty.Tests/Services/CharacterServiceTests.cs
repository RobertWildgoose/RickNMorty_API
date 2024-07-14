using ApiUtilities.Common.Interfaces;
using ApiUtilities.Common.Models;
using Moq;
using Newtonsoft.Json;
using RickNMorty.Common.Models.Characters;
using RickNMorty.Common.Models.Common;
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
	public class CharacterServiceTests
	{
		private readonly Mock<IHttpClientService> _httpClientServiceMock;
		private readonly Mock<IBaseConfiguration> _baseConfigMock;
		private readonly CharacterService _characterService;

		public CharacterServiceTests()
		{
			_httpClientServiceMock = new Mock<IHttpClientService>();
			_baseConfigMock = new Mock<IBaseConfiguration>();

			_baseConfigMock.SetupGet(c => c.BaseUrl).Returns("https://example.com");
			_baseConfigMock.SetupGet(c => c.TimeoutSeconds).Returns(30);

			_characterService = new CharacterService(_httpClientServiceMock.Object, _baseConfigMock.Object);
		}

		[Fact]
		public async Task GetAllCharacters_SuccessfulRequest_ReturnsCharactersResponse()
		{
			// Arrange
			var expectedResponse = new CharactersResponse
			{
				Info = new ResponseInfo { Count = 3, Pages = 1, Next = null, Previous = null },
				Results = new List<Character>
				{
				new Character { Id = 1, Name = "Character 1" ,Success =  true},
				new Character { Id = 2, Name = "Character 2" ,Success =  true},
				new Character { Id = 3, Name = "Character 3" ,Success =  true}
				}
			};
			var responseContainer = new ResponseContainer<CharactersResponse>
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
			var result = await _characterService.GetAllCharacters(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedResponse.Info.Count, result.Info.Count);
			Assert.Equal(expectedResponse.Results.Count, result.Results.Count);
		}

		[Fact]
		public async Task GetCharacter_SuccessfulRequest_ReturnsCharacter()
		{
			// Arrange
			var expectedCharacter = new Character { Id = 1, Name = "Test Character", Success = true };
			var responseContainer = new ResponseContainer<Character>
			{
				Data = expectedCharacter
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
			var result = await _characterService.GetCharacter(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedCharacter.Id, result.Id);
			Assert.Equal(expectedCharacter.Name, result.Name);
		}

		[Fact]
		public async Task GetCharacters_ByIdList_SuccessfulRequest_ReturnsCharactersList()
		{
			// Arrange
			var characterIds = new List<int> { 1, 2, 3 };
			var expectedCharacters = new List<Character>
		{
			new Character { Id = 1, Name = "Character 1" ,Success =  true},
			new Character { Id = 2, Name = "Character 2" ,Success =  true},
			new Character { Id = 3, Name = "Character 3" ,Success =  true}
		};

			foreach (var character in expectedCharacters)
			{
				var responseContainer = new ResponseContainer<Character>
				{
					Data = character
				};
				var jsonResponse = JsonConvert.SerializeObject(responseContainer.Data);

				var httpResponseMessage = new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
				};

				_httpClientServiceMock.Setup(s => s.GetAsync($"https://example.com/character/{character.Id}", It.IsAny<CancellationToken>()))
					.ReturnsAsync(httpResponseMessage);
			}

			// Act
			var result = await _characterService.GetCharacters(characterIds);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedCharacters.Count, result.Count);
			for (int i = 0; i < expectedCharacters.Count; i++)
			{
				Assert.Equal(expectedCharacters[i].Id, result[i].Id);
				Assert.Equal(expectedCharacters[i].Name, result[i].Name);
			}
		}

		[Fact]
		public async Task GetCharacters_ByIdList_EmptyList_ReturnsEmptyList()
		{
			// Act
			var result = await _characterService.GetCharacters(new List<int>());

			// Assert
			Assert.NotNull(result);
			Assert.Empty(result);
		}
	}
}
