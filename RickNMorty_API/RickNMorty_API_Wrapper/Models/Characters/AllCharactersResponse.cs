using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RickNMorty_API_Wrapper.Models.Common;

namespace RickNMorty_API_Wrapper.Models.Characters
{
    public class AllCharactersResponse : BaseResponse
    {
        public ResponseInfo info { get; set; }
        public List<CharacterResponse> results { get; set; }
    }
}
