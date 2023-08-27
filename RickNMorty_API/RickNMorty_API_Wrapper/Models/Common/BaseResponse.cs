using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickNMorty_API_Wrapper.Models.Common
{
    public class BaseResponse
    {
        public bool IsSuccessful { get; set; }
        public string? error { get; set; }
    }
}
