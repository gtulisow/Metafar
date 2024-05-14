using atm.api.infrastructure.DTOs.Request;
using atm.api.infrastructure.DTOs.Response;
using MediatR;

namespace atm.api.infrastructure.Commands
{
    public record WithdrawalCommand(WithdrawalRequestDto WithdrawalRequest) : IRequest<WithdrawalResponseDto>;
}
