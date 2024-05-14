using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.infrastructure.DTOs.Response
{
    public class BalanceResponseDto
    {
        public string UserName { get; set; }
        public string AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime LastTransactionDate { get; set; }
    }
}
