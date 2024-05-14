using atm.api.data.Repositories;
using atm.api.domain;
using atm.api.infrastructure.DTOs.Response;
using atm.api.infrastructure.Queries.Operation;
using MediatR;

namespace atm.api.application.Handlers
{
    public class GetOperationsAllPaginatedHandler : IRequestHandler<GetOperationsAllPaginatedQuery, IEnumerable<OperationResponseDto>?>
    {
        #region Fields

        private readonly IOperationRepository _operationRepository;

        #endregion

        #region Constructor

        public GetOperationsAllPaginatedHandler(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<OperationResponseDto>?> Handle(GetOperationsAllPaginatedQuery request, CancellationToken cancellationToken)
        {
            var operationList = await _operationRepository.GetOperationsByCardNumber(request.cardNumber, request.pageNumber, request.pageSize);

            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException("La operación ha sido cancelada.");
            }

            if (operationList == null) { return null; }

            return operationList.Select(operationdto => new OperationResponseDto
            {
                Id = operationdto.Id,
                CardNumber = operationdto.Card.CardNumber,
                Amount = operationdto.Amount,
                OperationDateTime = operationdto.OperationDateTime,
                OperationTypeName = operationdto.OperationType.Name
            });
        }

        #endregion
    }
}
