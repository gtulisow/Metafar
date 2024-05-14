using atm.api.infrastructure.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.infrastructure.Queries.UserAccount
{
    public record GetUserAccountAllQuery : IRequest<IEnumerable<UserAccountResponseDto>?>;
}
