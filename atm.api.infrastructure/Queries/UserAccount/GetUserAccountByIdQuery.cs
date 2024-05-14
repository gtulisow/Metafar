using atm.api.infrastructure.DTOs.Response;
using MediatR;

namespace atm.api.infrastructure.Queries.UserAccount
{
    public record GetUserAccountByIdQuery(int Id) : IRequest<UserAccountResponseDto?>;
}
