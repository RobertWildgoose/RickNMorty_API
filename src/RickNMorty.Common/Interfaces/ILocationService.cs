using RickNMorty.Common.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Interfaces
{
	public interface ILocationService
	{
		public Task<Location> GetLocation(int locationId);
		public Task<List<Location>> GetLocations(IEnumerable<int> locationIds);
		public Task<LocationResponse> GetLocations(int page);
	}
}
