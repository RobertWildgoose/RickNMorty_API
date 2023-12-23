using ApiUtilities.Common.Interfaces;
using ApiUtilities.Common.Services;
using RickNMorty.Common.Interfaces;
using RickNMorty.Common.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Services
{
	public class CharacterService : BaseService, ICharacterService
	{
		public CharacterService(IApiConfig apiConfig, IExceptionHandler exceptionHandler, IRequestHandler requestHandler) : base(apiConfig, exceptionHandler, requestHandler)
		{

		}

		public async Task<CharactersResponse> GetAllCharacters(int page)
		{
			var response = await GetData<CharactersResponse>($"character?page={page}");
			return response;
		}

		public async Task<Character> GetCharacter(int characterId)
		{
			var response = await GetData<Character>($"character/{characterId}");
			return response;
		}

		public async Task<List<Character>> GetCharacters(IEnumerable<int> characters)
		{
			if (characters != null && characters.Count() > 0)
			{
				var arrayAsString = String.Join(',', characters);
				var response = await GetDataList<Character>($"character/{arrayAsString}");
				return response;
			}
			return null;
		}
	}
}
