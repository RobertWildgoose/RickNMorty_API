using RickNMorty.Common.Models.Episodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Interfaces
{
	public interface IEpisodeService
	{
		public Task<Episode> GetEpisode(int episodeId);
		public Task<List<Episode>> GetEpisodes(IEnumerable<int> episodeIds);
		public Task<EpisodeResponse> GetAllEpisodes(int page);
	}
}
