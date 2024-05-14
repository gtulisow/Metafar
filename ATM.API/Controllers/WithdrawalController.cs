using atm.api.infrastructure.Commands;
using atm.api.infrastructure.DTOs.Request;
using atm.api.infrastructure.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace atm.api.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WithdrawalController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public WithdrawalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Public Methods

        [HttpPost]
        public async Task<ActionResult<WithdrawalResponseDto>> Withdraw(WithdrawalRequestDto requestDto)
        {
            try
            {
                var command = new WithdrawalCommand(requestDto);

                var result = await _mediator.Send(command);

                return Ok(result);

            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

    }
}
