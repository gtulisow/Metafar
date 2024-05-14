using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.infrastructure.DTOs.Response
{
    public class TokenResponseDto
    {
        public string Token { get; set; } 

        public DateTime Expiration { get; set; }
    }
}
