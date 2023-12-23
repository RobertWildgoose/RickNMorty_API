using ApiUtilities.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Models.Episodes
{
	public class Episode : BaseResponse
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "air_date")]
		public string AirDate { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public string EpisodeTitle { get; set; }

		[JsonProperty(PropertyName = "characters")]
		public List<string> Characters { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "created")]
		public string Created { get; set; }
	}
}
