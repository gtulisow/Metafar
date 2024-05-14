using atm.api.infrastructure.Commands;
using atm.api.infrastructure.DTOs.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace atm.api.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        #region Fields

        private readonly IConfiguration _config;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public SecurityController(IConfiguration config, IMediator mediator)
        {
            _config = config;
            _mediator = mediator;
        }

        #endregion

        #region Public Methods

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequest)
        {
            try
            {
                var command = new LoginCommand(loginRequest);
                var token = await _mediator.Send(command);

                return Ok(token);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
