using ApiUtilities.Common.Models;
using Newtonsoft.Json;
using RickNMorty.Common.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Models.Episodes
{
    public class EpisodeResponse : BaseResponse
	{
		[JsonProperty(PropertyName = "info")]
		public ResponseInfo Info { get; set; }

		[JsonProperty(PropertyName = "results")]
		public List<Episode> Results { get; set; }
	}
}
