using atm.api.infrastructure.DTOs.Request;
using atm.api.infrastructure.DTOs.Response;
using MediatR;

namespace atm.api.infrastructure.Commands
{
    public record LoginCommand(LoginRequestDto LoginRequest) : IRequest<TokenResponseDto>;
}
