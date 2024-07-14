using ApiUtilities.Common.Interfaces;
using ApiUtilities.Common.Services;
using RickNMorty.Common.Interfaces;
using RickNMorty.Common.Models.Characters;
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
		public EpisodeService(IHttpClientService httpClientService, IBaseConfiguration apiConfig) : base(httpClientService, apiConfig)
		{

		}

		public async Task<EpisodeResponse> GetAllEpisodes(int page)
		{
			var response = await Get<EpisodeResponse>($"episode?page={page}");
			if (response != null && response.Success)
			{
				return response.Data;
			}
			return null;
		}

		public async Task<Episode> GetEpisode(int episodeId)
		{
			var response = await Get<Episode>($"episode/{episodeId}");
			if (response != null && response.Success)
			{
				return response.Data;
			}
			return null;
		}

		public async Task<List<Episode>> GetEpisodes(IEnumerable<int> episodeIds)
		{
			if (episodeIds != null && episodeIds.Any())
			{
				var episodeList = new List<Episode>();
				foreach (var episode in episodeIds)
				{
					var response = await GetEpisode(episode);
					if (response != null && response.Success)
					{
						episodeList.Add(response);
					}
				}
				return episodeList;
			}
			return new List<Episode>();
		}
	}
}
