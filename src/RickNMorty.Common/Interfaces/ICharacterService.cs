using ApiUtilities.Common.Services;
using RickNMorty.Common.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Interfaces
{
	public interface ICharacterService
	{
		public Task<Character> GetCharacter(int characterId);
		public Task<List<Character>> GetCharacters(IEnumerable<int> characters);
		public Task<CharactersResponse> GetAllCharacters(int page);
	}
}
