using ApiUtilities.Common.Interfaces;
using ApiUtilities.Common.Services;
using RickNMorty.Common.Interfaces;
using RickNMorty.Common.Models.Episodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Services
{
	public class EpisodeService : BaseService, IEpisodeService
	{
		public EpisodeService(IApiConfig apiConfig, IExceptionHandler exceptionHandler, IRequestHandler requestHandler) : base(apiConfig, exceptionHandler, requestHandler)
		{

		}

		public async Task<EpisodeResponse> GetAllEpisodes(int page)
		{
			var response = await GetData<EpisodeResponse>($"episode?page={page}");
			return response;
		}

		public async Task<Episode> GetEpisode(int episodeId)
		{
			var response = await GetData<Episode>($"episode/{episodeId}");
			return response;
		}

		public async Task<List<Episode>> GetEpisodes(IEnumerable<int> episodeIds)
		{
			if (episodeIds != null && episodeIds.Count() > 0)
			{
				var arrayAsString = String.Join(',', episodeIds);
				var response = await GetDataList<Episode>($"episode/{arrayAsString}");
				return response;
			}
			return null;
		}
	}
}
