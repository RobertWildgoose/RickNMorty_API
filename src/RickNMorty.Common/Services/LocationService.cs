using ApiUtilities.Common.Interfaces;
using ApiUtilities.Common.Services;
using RickNMorty.Common.Interfaces;
using RickNMorty.Common.Models.Characters;
using RickNMorty.Common.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Services
{
	public class LocationService : BaseService, ILocationService
	{

		public LocationService(IHttpClientService httpClientService, IBaseConfiguration apiConfig) : base(httpClientService, apiConfig)
		{

		}

		public async Task<Location> GetLocation(int locationId)
		{
			var response = await Get<Location>($"location/{locationId}");
			if (response != null && response.Success)
			{
				return response.Data;
			}
			return null;
		}

		public async Task<List<Location>> GetLocations(IEnumerable<int> locationIds)
		{
			if (locationIds != null && locationIds.Any())
			{
				var characterList = new List<Location>();
				foreach (var location in locationIds)
				{
					var response = await GetLocation(location);
					if (response != null && response.Success)
					{
						characterList.Add(response);
					}
				}
				return characterList;
			}
			return new List<Location>();
		}

		public async Task<LocationResponse> GetLocations(int page)
		{
			var response = await Get<LocationResponse>($"location?page={page}");
			if (response != null && response.Success)
			{
				return response.Data;
			}
			return null;
		}
	}
}
