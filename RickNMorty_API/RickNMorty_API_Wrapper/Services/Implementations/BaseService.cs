using Newtonsoft.Json;
using RickNMorty_API_Wrapper.Models.Common;
using RickNMorty_API_Wrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Services.Implementations
{
    public class BaseService
    {
        private IRequestService _requestService;
        private const string character_doesnt_exist = @"{'error': 'Character not found'}";
        private const string location_doesnt_exist = @"{'error': 'Location not found'}";
        private const string episode_doesnt_exist = @"{'error': 'Episode not found'}";
        
        private const string id_doesnt_exist = @"{'error': Hey! you must provide an id'}";
        private const string page_doesnt_exist = @"{'error': There is nothing here'}";

        public BaseService(IRequestService requestService) 
        {
            _requestService = requestService;
        }

        public async Task<string> Get(string url)
        {
            if(!string.IsNullOrWhiteSpace(url))
            {
                return await _requestService.Get($"{Constants.BaseUrl}{url}");
            }
            return string.Empty;
        }

        public async Task<T> ConvertItem<T>(string data) where T : BaseResponse
        {
            if (!string.IsNullOrWhiteSpace(data))
            {
                try
                {
                    var deserializeObject = JsonConvert.DeserializeObject<T>(data);
                    if (deserializeObject != null)
                    {
                        deserializeObject.IsSuccessful = true;
                        deserializeObject.error = null;
                        return await Task.FromResult<T>(deserializeObject);
                    }
                }
                catch (Exception e)
                {
                    return await Task.FromResult<T>(result: null);
                }
            }
            return await Task.FromResult<T>(result: null);
        }

        public async Task<List<T>> ConvertItemList<T>(string data) where T : BaseResponse
        {
            if (!string.IsNullOrWhiteSpace(data))
            {
                var deserializeObject = JsonConvert.DeserializeObject<List<T>>(data);
                if (deserializeObject != null)
                {
                    return await Task.FromResult<List<T>>(deserializeObject);
                }
            }
            return await Task.FromResult<List<T>>(result: null);
        }

        public string CheckForResponseErrors(string request)
        {
            if (!string.IsNullOrWhiteSpace(request))
            {
                switch (request)
                {
                    case (location_doesnt_exist):
                        return "location_not_found";
                    case (character_doesnt_exist):
                        return "character_not_found";
                    case (episode_doesnt_exist):
                        return "episode_not_found";
                    case (id_doesnt_exist):
                        return "invalid_id";
                    case (page_doesnt_exist):
                        return "invalid_page";
                    default:
                        return string.Empty;
                }
            }
            return "invalid_response";
        }
    }
}
