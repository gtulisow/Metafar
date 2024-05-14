using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.domain
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public DateTime LastAccessDate { get; set; }
        public int FailedAccessAttempts { get; private set; } = 0;

        public void AddFailedAccessAttempts()
        {
            FailedAccessAttempts++;
        }

        public void ResetFailedAccessAttempts()
        {
            FailedAccessAttempts = 0;
        }
    }
}

 