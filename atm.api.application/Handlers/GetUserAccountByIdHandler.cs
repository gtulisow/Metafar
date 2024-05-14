using atm.api.data.Repositories;
using atm.api.infrastructure.DTOs.Response;
using atm.api.infrastructure.Queries;
using atm.api.infrastructure.Queries.UserAccount;
using MediatR;

namespace atm.api.application.Handlers
{

    public class GetUserAccountByIdHandler : IRequestHandler<GetUserAccountByIdQuery, UserAccountResponseDto?>
    {
        #region Fields

        private readonly IUserAccountRepository _userAccountRepository;

        #endregion

        #region Constructor

        public GetUserAccountByIdHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        #endregion

        #region Public Methods

        public async Task<UserAccountResponseDto?> Handle(GetUserAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetById(request.Id);

            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException("La operación ha sido cancelada.");
            }

            if (userAccount == null) { return null; }

            return new UserAccountResponseDto
            {
                Id = userAccount.Id,
                Balance = userAccount.Card.Balance,
                Name = userAccount.Name,
            };
        }

        #endregion
    }
}
