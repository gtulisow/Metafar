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
    public class OperationRepository : IOperationRepository
    {
        private readonly AppDBContext _dbContext;

        public OperationRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Operation operation)
        {
            await _dbContext.Operations.AddAsync(operation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Operation?> GetLastOperationsByCardNumber(string cardNumber)
        {
            return await _dbContext.Operations
                .Include(o => o.Card)
                .Where(o => o.Card.CardNumber == cardNumber)
                .OrderByDescending(o => o.OperationDateTime)
                .FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Operation>?> GetOperationsByCardNumber(string cardNumber, int pageNumber, int pageSize)
        {
            
            return await _dbContext.Operations
                .Include(ot => ot.OperationType)
                .Include(o => o.Card)
                .Where(o => o.Card.CardNumber == cardNumber)
                .OrderByDescending(o => o.OperationDateTime)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
