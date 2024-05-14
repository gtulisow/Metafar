using atm.api.data.Repositories;
using atm.api.infrastructure.DTOs.Response;
using atm.api.infrastructure.Queries.UserAccount;
using MediatR;

namespace atm.api.application.Handlers
{

    public class GetUserAccountBalanceByCardNumberHandler : IRequestHandler<GetUserAccountBalanceByCardNumberQuery, BalanceResponseDto?>
    {
        #region Fields

        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IOperationRepository _operationRepository;

        #endregion

        #region Constructor

        public GetUserAccountBalanceByCardNumberHandler(IUserAccountRepository userAccountRepository, IOperationRepository operationRepository)
        {
            _userAccountRepository = userAccountRepository;
            _operationRepository = operationRepository;
        }

        #endregion
   
        #region Public Methods

        public async Task<BalanceResponseDto?> Handle(GetUserAccountBalanceByCardNumberQuery request, CancellationToken cancellationToken)
        {

            var userAccount = await _userAccountRepository.GetUserAccountByCardNumber(request.cardNumber);

            var lastOperation = await _operationRepository.GetLastOperationsByCardNumber(request.cardNumber);

            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException("La operación ha sido cancelada.");
            }

            if (lastOperation == null || userAccount == null) { return null; }

            return new BalanceResponseDto
            {
                AccountNumber = userAccount.Card.CardNumber,
                CurrentBalance = userAccount.Card.Balance,
                LastTransactionDate = lastOperation.OperationDateTime,
                UserName = userAccount.Name,
            };
        }

        #endregion
    }
}
