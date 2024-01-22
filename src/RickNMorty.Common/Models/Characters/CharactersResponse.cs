using ApiUtilities.Common.Models;
using Newtonsoft.Json;
using RickNMorty.Common.Models.Common;
using RickNMorty.Common.Models.Episodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common.Models.Characters
{
	public class CharactersResponse : BaseResponse
	{
		[JsonProperty(PropertyName = "info")]
		public ResponseInfo Info { get; set; }

		[JsonProperty(PropertyName = "results")]
		public List<Character> Results { get; set; }
	}
}
