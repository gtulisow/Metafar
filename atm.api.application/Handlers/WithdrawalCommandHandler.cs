
using atm.api.data.Repositories;
using atm.api.domain;
using atm.api.infrastructure.Commands;
using atm.api.infrastructure.DTOs.Response;
using MediatR;

namespace atm.api.application.Handlers
{
    public class WithdrawalCommandHandler : IRequestHandler<WithdrawalCommand, WithdrawalResponseDto>
    {

        #region Fields

        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IOperationRepository _operationRepository;

        #endregion

        #region Constructor

        public WithdrawalCommandHandler(IUserAccountRepository userAccountRepository, IOperationRepository operationRepository)
        {
            _userAccountRepository = userAccountRepository;
            _operationRepository = operationRepository;
        }

        #endregion

        #region Public Methods

        public async Task<WithdrawalResponseDto> Handle(WithdrawalCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetUserAccountByCardNumber(request.WithdrawalRequest.CardNumber);

            if (userAccount == null)
            {
                // Si no se encuentra la cuenta, retorna un error
                throw new ApplicationException("Tarjeta no encontrada");
            }

            if (request.WithdrawalRequest.Amount > userAccount.Card.Balance)
            {
                // Si el monto a retirar es mayor al saldo, retorna un error
                throw new ApplicationException("Saldo insuficiente");
            }

            userAccount.Card.Balance -= request.WithdrawalRequest.Amount;


            await _userAccountRepository.Update(userAccount);


            var withdrawalOperation = new Operation
            {
                OperationTypeId = 2, /// TODO: traer info de la DB
                CardId = userAccount.CardId,
                Amount = request.WithdrawalRequest.Amount,
                OperationDateTime = DateTime.Now
                
            };

            await _operationRepository.Add(withdrawalOperation);


            var response = new WithdrawalResponseDto
            {
                CardNumber = request.WithdrawalRequest.CardNumber,
                AmountWithdrawn = request.WithdrawalRequest.Amount,
                NewBalance = userAccount.Card.Balance,
                TransactionDateTime = DateTime.Now
            };

            return response;
        }

        #endregion
    }
}
