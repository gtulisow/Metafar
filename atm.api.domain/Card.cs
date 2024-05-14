using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.domain
{
    public class Card
    {
        public int Id { get; set; } 
        public string CardNumber { get; set; }
        public string PIN { get; set; }
        public decimal Balance { get; set; }
        public bool Enabled { get; private set; } = true;

        public void Lock() 
        {
            Enabled = false;
        }

        public void UnLock()
        {
            Enabled = true;
        }
    }
}
