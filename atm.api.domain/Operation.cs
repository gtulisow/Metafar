using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.domain
{
    public class Operation
    {
        public int Id { get; set; }
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public decimal Amount { get; set; }
        public DateTime OperationDateTime { get; set; }
    }
}
