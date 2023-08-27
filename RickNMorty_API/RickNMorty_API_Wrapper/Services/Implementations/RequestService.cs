using Newtonsoft.Json;
using RickNMorty_API_Wrapper.Models;
using RickNMorty_API_Wrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Services.Implementations
{
    public class RequestService : IRequestService
    {
        public async Task<string> Get(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }
            return string.Empty;
        }
    }
}
