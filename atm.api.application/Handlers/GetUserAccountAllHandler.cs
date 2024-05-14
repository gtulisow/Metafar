using atm.api.data.Repositories;
using atm.api.infrastructure.DTOs.Response;
using atm.api.infrastructure.Queries.UserAccount;
using MediatR;

namespace atm.api.application.Handlers
{

    public class GetUserAccountAllHandler : IRequestHandler<GetUserAccountAllQuery, IEnumerable<UserAccountResponseDto>?>
    {
        #region Fields

        private readonly IUserAccountRepository _userAccountRepository;

        #endregion

        #region Constructor

        public GetUserAccountAllHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<UserAccountResponseDto>?> Handle(GetUserAccountAllQuery request, CancellationToken cancellationToken)
        {
            var userAccounts = await _userAccountRepository.GetAll();

            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException("La operación ha sido cancelada.");
            }

            if (userAccounts == null) { return null; }

            return userAccounts.Select(user => new UserAccountResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Balance = user.Card.Balance,
            });
        }

        #endregion
    }
}
