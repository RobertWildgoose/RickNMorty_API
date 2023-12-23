using ApiUtilities.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Models
{
	public class ResponseInfo : BaseResponse
	{
		[JsonProperty(PropertyName = "count")]
		public int Count { get; set; }

		[JsonProperty(PropertyName = "pages")]
		public int Pages { get; set; }

		[JsonProperty(PropertyName = "next")]
		public string Next { get; set; }

		[JsonProperty(PropertyName = "prev")]
		public string Previous { get; set; }
	}
}
