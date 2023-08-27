using RickNMorty_API_Wrapper.Models.Characters;
using RickNMorty_API_Wrapper.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Models.Locations
{
    public class AllLocationsResponse : BaseResponse
    {
        public ResponseInfo info { get; set; }
        public List<LocationResponse> results { get; set; }
    }
}
