using atm.api.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace atm.api.data.Repositories
{
    public interface IUserAccountRepository
    {
        Task<IEnumerable<UserAccount>?> GetAll();
        
        Task<UserAccount?> GetById(int id);
         
        Task<UserAccount?> GetUserAccountByCardNumber(string cardNumber);

        Task Update(UserAccount userAccount);

        Task<UserAccount?> GetUserByCardNumber(string cardNumber);

        Task<bool> AddFailedAccess(string cardNumber);

        Task<bool> ResetFailedAccessAttempts(string cardNumber);

        Task<bool> LookCard(string cardNumber);
         
    }
}
