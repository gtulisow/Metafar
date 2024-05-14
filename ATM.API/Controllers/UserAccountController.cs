using MediatR;
using Microsoft.AspNetCore.Mvc;
using atm.api.infrastructure.Queries.UserAccount;
using atm.api.infrastructure.DTOs.Response;
using Microsoft.AspNetCore.Authorization;

namespace atm.api.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserAccountController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public UserAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccountResponseDto>?>> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetUserAccountAllQuery());
                return Ok(response);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccountResponseDto>> GetById(int id)
        {
            try
            {
                var query = new GetUserAccountByIdQuery(id);
                var user = await _mediator.Send(query);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Balance/{cardNumber}")]
        public async Task<ActionResult<BalanceResponseDto>> GetBalanceByCardNumber(string cardNumber)
        {
            try
            {
                var query = new GetUserAccountBalanceByCardNumberQuery(cardNumber);
                var balance = await _mediator.Send(query);
                if (balance == null)
                {
                    return NotFound();
                }
                return Ok(balance);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

    }
}