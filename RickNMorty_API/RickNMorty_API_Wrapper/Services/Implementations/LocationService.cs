using RickNMorty_API_Wrapper.Models.Characters;
using RickNMorty_API_Wrapper.Models.Locations;
using RickNMorty_API_Wrapper.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Services.Implementations
{
    public class LocationService : BaseService, ILocationService
    {
        public LocationService(IRequestService requestService) : base(requestService)
        {
        }

        public async Task<AllLocationsResponse> GetAll(int page)
        {
            if (page > 0)
            {
                var request = await Get($"location?page={page}");
                var errors = CheckForResponseErrors(request);
                if (!string.IsNullOrEmpty(errors))
                {
                    return new AllLocationsResponse() { IsSuccessful = false, error = errors };
                }
                else
                {
                    var modelled = await ConvertItem<AllLocationsResponse>(request);
                    if (modelled != null && modelled.IsSuccessful)
                    {
                        return modelled;
                    }
                    return new AllLocationsResponse() { IsSuccessful = false, error = "invalid_conversion" };
                }
            }
            return new AllLocationsResponse() { IsSuccessful = false, error = "invalid_page" };
        }

        public async Task<LocationResponse> GetItem(int locationId)
        {
            if (locationId > 0)
            {
                var request = await Get($"location/{locationId}");
                var errors = CheckForResponseErrors(request);
                if (!string.IsNullOrEmpty(errors))
                {
                    return new LocationResponse() { IsSuccessful = false, error = errors };
                }
                else
                {
                    var modelled = await ConvertItem<LocationResponse>(request);
                    if (modelled != null && modelled.IsSuccessful)
                    {
                        return modelled;
                    }
                    return new LocationResponse() { IsSuccessful = false, error = "invalid_conversion" };
                }
            }
            return new LocationResponse() { IsSuccessful = false, error = "invalid_id" };
        }

        public async Task<List<LocationResponse>> GetItems(IEnumerable<int> locationIds)
        {
            if (locationIds != null && locationIds.Count() > 0)
            {
                var arrayAsString = String.Join(',', locationIds);
                var request = await Get($"location/{arrayAsString}");
                var errors = CheckForResponseErrors(request);
                if (!string.IsNullOrEmpty(errors))
                {
                    return new List<LocationResponse>();
                }
                else
                {
                    var modelled = await ConvertItemList<LocationResponse>(request);
                    if (modelled != null)
                    {
                        return modelled;
                    }
                    return new List<LocationResponse>();
                }
            }
            return new List<LocationResponse>();
        }
    }
}
