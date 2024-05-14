using atm.api.infrastructure.DTOs.Response;
using MediatR;

namespace atm.api.infrastructure.Queries.UserAccount
{
    public record GetUserAccountBalanceByCardNumberQuery(string cardNumber) : IRequest<BalanceResponseDto?>;
}
