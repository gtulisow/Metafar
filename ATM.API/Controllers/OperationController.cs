using atm.api.infrastructure.DTOs.Response;
using atm.api.infrastructure.Queries.Operation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace atm.api.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OperationController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;
        private const int PageSize = 10;

        #endregion

        #region Constructor

        public OperationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Public Methods

        [HttpGet("Paginated")]        
        public async Task<ActionResult<IEnumerable<OperationResponseDto>?>> GetAllOperationPaginated(string cardNumber, int pageNumber)
        {
            try
            {
                var query = new GetOperationsAllPaginatedQuery(cardNumber, pageNumber, PageSize);
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
