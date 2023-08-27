using RickNMorty_API_Wrapper.Models.Characters;
using RickNMorty_API_Wrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Services.Implementations
{
    public class CharacterService : BaseService, ICharacterService
    {
        public CharacterService(IRequestService requestService) : base(requestService)
        {

        }

        public async Task<CharacterResponse> GetItem(int characterId)
        {
            if (characterId > 0)
            {
                var request = await Get($"character/{characterId}");
                var errors = CheckForResponseErrors(request);
                if (!string.IsNullOrEmpty(errors))
                {
                    return new CharacterResponse() { IsSuccessful = false, error = errors };
                }
                else
                {
                    var modelled = await ConvertItem<CharacterResponse>(request);
                    if (modelled != null && modelled.IsSuccessful)
                    {
                        return modelled;
                    }
                    return new CharacterResponse() { IsSuccessful = false, error = "invalid_conversion" };
                }
            }
            return new CharacterResponse() { IsSuccessful = false, error = "invalid_id" };
        }

        public async Task<AllCharactersResponse> GetAll(int page)
        {
            if (page > 0)
            {
                var request = await Get($"character?page={page}");
                var errors = CheckForResponseErrors(request);
                if (!string.IsNullOrEmpty(errors))
                {
                    return new AllCharactersResponse() { IsSuccessful = false, error = errors };
                }
                else
                {
                    var modelled = await ConvertItem<AllCharactersResponse>(request);
                    if (modelled != null && modelled.IsSuccessful)
                    {
                        return modelled;
                    }
                    return new AllCharactersResponse() { IsSuccessful = false, error = "invalid_conversion" };
                }
            }
            return new AllCharactersResponse() { IsSuccessful = false, error = "invalid_id" };
        }

        public async Task<List<CharacterResponse>> GetItems(IEnumerable<int> characters)
        {
            if (characters != null && characters.Count() > 0)
            {
                var arrayAsString = String.Join(',', characters);
                var request = await Get($"character/{arrayAsString}");
                var errors = CheckForResponseErrors(request);
                if (!string.IsNullOrEmpty(errors))
                {
                    return new List<CharacterResponse>();
                }
                else
                {
                    var modelled = await ConvertItemList<CharacterResponse>(request);
                    if (modelled != null)
                    {
                        return modelled;
                    }
                    return new List<CharacterResponse>();
                }
            }
            return new List<CharacterResponse>();
        }
    }
}
