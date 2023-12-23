using ApiUtilities.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Models.Characters
{
	public class Character : BaseResponse
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "status")]
		public string Status { get; set; }

		[JsonProperty(PropertyName = "species")]
		public string Species { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "gender")]
		public string Gender { get; set; }

		[JsonProperty(PropertyName = "image")]
		public string Image { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "created")]
		public string Created { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public List<string> Episodes { get; set; }

		[JsonProperty(PropertyName = "location")]
		public Summary Location { get; set; }

		[JsonProperty(PropertyName = "origin")]
		public Summary Origin { get; set; }
	}
}
