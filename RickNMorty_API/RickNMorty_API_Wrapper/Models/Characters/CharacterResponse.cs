using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RickNMorty_API_Wrapper.Models.Common;

namespace RickNMorty_API_Wrapper.Models.Characters
{
    public class CharacterResponse : BaseResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        public string created { get; set; }
        public List<string> episode { get; set; }
        public LocationSummary location { get; set; }
        public LocationSummary origin { get; set; }
    }
}
