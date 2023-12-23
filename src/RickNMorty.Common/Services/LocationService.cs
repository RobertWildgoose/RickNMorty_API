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
		public LocationService(IApiConfig apiConfig, IExceptionHandler exceptionHandler, IRequestHandler requestHandler) : base(apiConfig, exceptionHandler, requestHandler)
		{

		}

		public async Task<Location> GetLocation(int locationId)
		{
			var response = await GetData<Location>($"location/{locationId}");
			return response;
		}

		public async Task<List<Location>> GetLocations(IEnumerable<int> locationIds)
		{
			if (locationIds != null && locationIds.Count() > 0)
			{
				var arrayAsString = String.Join(',', locationIds);
				var response = await GetDataList<Location>($"location/{arrayAsString}");
				return response;
			}
			return null;
		}

		public async Task<LocationResponse> GetLocations(int page)
		{
			var response = await GetData<LocationResponse>($"location?page={page}");
			return response;
		}
	}
}
