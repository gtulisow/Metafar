using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.infrastructure.DTOs.Response
{
    public class WithdrawalResponseDto
    {
        public string CardNumber { get; set; }
        public decimal AmountWithdrawn { get; set; }
        public decimal NewBalance { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}
