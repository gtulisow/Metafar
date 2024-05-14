using atm.api.data.DBContext;
using atm.api.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.data.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly AppDBContext _dbContext;

        public UserAccountRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UserAccount>?> GetAll()
        {
            var users = await _dbContext.UsersAccount
                                .Include(u => u.Card)
                                .ToListAsync();

            return users;
        }

        public async Task<UserAccount?> GetUserAccountByCardNumber(string cardNumber)
        {
            var userAccount = await _dbContext.UsersAccount
                                     .Include(u => u.Card)
                                     .FirstOrDefaultAsync(u => u.Card.CardNumber == cardNumber);

            return userAccount;
        }

        public async Task<UserAccount?> GetById(int id)
        {
            var user = await _dbContext.UsersAccount
                                .Include(u => u.Card)
                                .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task Update(UserAccount userAccount)
        {
            _dbContext.UsersAccount.Update(userAccount);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserAccount?> GetUserByCardNumber(string cardNumber)
        {
            return await _dbContext.UsersAccount
                .Include(u => u.Card)
                .FirstOrDefaultAsync(u => u.Card.CardNumber == cardNumber);
        }

        public async Task<bool> AddFailedAccess(string cardNumber)
        {
            var user = await _dbContext.UsersAccount
                .Include(u => u.Card)
                .FirstOrDefaultAsync(u => u.Card.CardNumber == cardNumber);

            if (user == null)
            {
                return false;
            }

            user.AddFailedAccessAttempts();
            await _dbContext.SaveChangesAsync();

            return true;
        }


        public async Task<bool> ResetFailedAccessAttempts(string cardNumber)
        {
            var user = await _dbContext.UsersAccount
                .Include(u => u.Card)
                .FirstOrDefaultAsync(u => u.Card.CardNumber == cardNumber);

            if (user == null)
            {
                return false;
            }

            user.ResetFailedAccessAttempts();
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> LookCard(string cardNumber)
        {
            var user = await _dbContext.UsersAccount
                .Include(u => u.Card)
                .FirstOrDefaultAsync(u => u.Card.CardNumber == cardNumber);

            if (user == null)
            {
                return false;
            }

            user.Card.Lock();
            await _dbContext.SaveChangesAsync();

            return true;
        }
         
    }
}
