using RickNMorty_API_Wrapper.Models.Common;
using RickNMorty_API_Wrapper.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Models.Episodes
{
    public class AllEpisodeResponse : BaseResponse
    {
        public ResponseInfo info { get; set; }
        public List<EpisodeResponse> results { get; set; }
    }
}
