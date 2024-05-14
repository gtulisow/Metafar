using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.infrastructure.DTOs.Request
{
    public class WithdrawalRequestDto
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }

    }
}
