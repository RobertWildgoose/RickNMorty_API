using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Services.Interfaces
{
    public interface IRequestService
    {
        public Task<string> Get(string url);
    }
}
