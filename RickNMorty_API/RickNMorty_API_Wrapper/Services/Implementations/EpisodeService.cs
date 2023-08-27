using RickNMorty_API_Wrapper.Models.Episodes;
using RickNMorty_API_Wrapper.Models.Locations;
using RickNMorty_API_Wrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Services.Implementations
{
    public class EpisodeService : BaseService, IEpisodeService
    {
        public EpisodeService(IRequestService requestService) : base(requestService)
        {
        }

        public async Task<AllEpisodeResponse> GetAll(int page)
        {
            if (page > 0)
            {
                var request = await Get($"episode?page={page}");
                var errors = CheckForResponseErrors(request);
                if (!string.IsNullOrEmpty(errors))
                {
                    return new AllEpisodeResponse() { IsSuccessful = false, error = errors };
                }
                else
                {
                    var modelled = await ConvertItem<AllEpisodeResponse>(request);
                    if (modelled != null && modelled.IsSuccessful)
                    {
                        return modelled;
                    }
                    return new AllEpisodeResponse() { IsSuccessful = false, error = "invalid_conversion" };
                }
            }
            return new AllEpisodeResponse() { IsSuccessful = false, error = "invalid_page" };
        }

        public async Task<EpisodeResponse> GetItem(int episodeId)
        {
            if (episodeId > 0)
            {
                var request = await Get($"episode/{episodeId}");
                var errors = CheckForResponseErrors(request);
                if (!string.IsNullOrEmpty(errors))
                {
                    return new EpisodeResponse() { IsSuccessful = false, error = errors };
                }
                else
                {
                    var modelled = await ConvertItem<EpisodeResponse>(request);
                    if (modelled != null && modelled.IsSuccessful)
                    {
                        return modelled;
                    }
                    return new EpisodeResponse() { IsSuccessful = false, error = "invalid_conversion" };
                }
            }
            return new EpisodeResponse() { IsSuccessful = false, error = "invalid_id" };
        }

        public async Task<List<EpisodeResponse>> GetItems(IEnumerable<int> episodeIds)
        {
            if (episodeIds != null && episodeIds.Count() > 0)
            {
                var arrayAsString = String.Join(',', episodeIds);
                var request = await Get($"episode/{arrayAsString}");
                var errors = CheckForResponseErrors(request);
                if (!string.IsNullOrEmpty(errors))
                {
                    return new List<EpisodeResponse>();
                }
                else
                {
                    var modelled = await ConvertItemList<EpisodeResponse>(request);
                    if (modelled != null)
                    {
                        return modelled;
                    }
                    return new List<EpisodeResponse>();
                }
            }
            return new List<EpisodeResponse>();
        }
    }
}
