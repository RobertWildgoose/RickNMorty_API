using ApiUtilities.Common.Interfaces;
using ApiUtilities.Common.Services;
using RickNMorty.Common.Interfaces;
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
		public LocationService(IApiConfig apiConfig, IRequestHandler requestHandler) : base(apiConfig, requestHandler)
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
			if (locationIds != null && locationIds.Count() > 0)
			{
				var arrayAsString = String.Join(',', locationIds);
				var response = await GetEnumerable<Location>($"location/{arrayAsString}");
				if (response != null && response.Success)
				{
					return response.Data;
				}
			}
			return null;
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
