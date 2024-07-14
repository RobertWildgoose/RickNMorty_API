using ApiUtilities.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty.Common
{
	public class ApiConfiguration : IBaseConfiguration
	{
		public string BaseUrl { get => "https://rickandmortyapi.com/api/"; }

		public string AuthToken => string.Empty;

		public IDictionary<string, string> Headers => new Dictionary<string, string>();

		public int TimeoutSeconds => 30;
	}
}
