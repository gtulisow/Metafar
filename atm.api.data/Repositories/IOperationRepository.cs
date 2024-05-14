using atm.api.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.data.Repositories
{
    public interface IOperationRepository
    {
        Task<IEnumerable<Operation>?> GetOperationsByCardNumber(string cardNumber, int pageNumber, int pageSize);

        Task<Operation?> GetLastOperationsByCardNumber(string cardNumber);

        Task Add(Operation operation);
    }
}
