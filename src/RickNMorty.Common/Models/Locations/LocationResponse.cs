using ApiUtilities.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Models.Locations
{
	public class LocationResponse : BaseResponse
	{
		[JsonProperty(PropertyName = "info")]
		public ResponseInfo Info { get; set; }

		[JsonProperty(PropertyName = "results")]
		public List<Location> Results { get; set; }
	}
}
