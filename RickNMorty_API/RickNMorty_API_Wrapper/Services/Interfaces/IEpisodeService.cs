using RickNMorty_API_Wrapper.Models.Episodes;
using RickNMorty_API_Wrapper.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Services.Interfaces
{
    public interface IEpisodeService
    {
        public Task<EpisodeResponse> GetItem(int episodeId);
        public Task<List<EpisodeResponse>> GetItems(IEnumerable<int> episodeIds);
        public Task<AllEpisodeResponse> GetAll(int page);
    }
}
