using atm.api.infrastructure.DTOs.Response;
using MediatR;

namespace atm.api.infrastructure.Queries.Operation
{

    public record GetOperationsAllPaginatedQuery(string cardNumber, int pageNumber, int pageSize) : IRequest<IEnumerable<OperationResponseDto>?>;
}
