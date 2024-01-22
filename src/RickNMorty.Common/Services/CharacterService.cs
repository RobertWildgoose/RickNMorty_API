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
		public CharacterService(IApiConfig apiConfig, IRequestHandler requestHandler) : base(apiConfig, requestHandler)
		{

		}

		public async Task<CharactersResponse> GetAllCharacters(int page)
		{
			var response = await Get<CharactersResponse>($"character?page={page}");
			if (response != null && response.Success)
			{
				return response.Data;
			}
			return null;
		}

		public async Task<Character> GetCharacter(int characterId)
		{
			var response = await Get<Character>($"character/{characterId}");
			if (response != null && response.Success)
			{
				return response.Data;
			}
			return null;
		}

		public async Task<List<Character>> GetCharacters(IEnumerable<int> characters)
		{
			if (characters != null && characters.Count() > 0)
			{
				var arrayAsString = String.Join(',', characters);
				var response = await GetEnumerable<Character>($"character/{arrayAsString}");
				if (response != null && response.Success)
				{
					return response.Data;
				}
			}
			return new List<Character>();
		}
	}
}
