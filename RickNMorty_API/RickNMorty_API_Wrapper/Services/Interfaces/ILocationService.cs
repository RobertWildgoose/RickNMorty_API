using RickNMorty_API_Wrapper.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<LocationResponse> GetItem(int locationId);
        public Task<List<LocationResponse>> GetItems(IEnumerable<int> locationIds);
        public Task<AllLocationsResponse> GetAll(int page);
    }
}
