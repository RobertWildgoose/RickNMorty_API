using RickNMorty_API_Wrapper.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Services.Interfaces
{
    public interface ICharacterService
    {
        public Task<AllCharactersResponse> GetAll(int page);
        public Task<CharacterResponse> GetItem(int characterId);
        public Task<List<CharacterResponse>> GetItems(IEnumerable<int> characters);
        //TODO: Add Filterable Requests
        //public Task<AllCharactersResponse> GetFilteredCharacters(IEnumerable<int> characters);
    }
}
