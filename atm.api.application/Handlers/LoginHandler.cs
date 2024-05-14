using atm.api.application.Models.Config;
using atm.api.data.Repositories;
using atm.api.domain;
using atm.api.infrastructure.Commands;
using atm.api.infrastructure.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace atm.api.application.Handlers
{

    public class LoginHandler : IRequestHandler<LoginCommand, TokenResponseDto>
    {
        #region Fields

        private readonly IUserAccountRepository _userRepository;
        private readonly SecurityServiceConfiguration _securitySettings;

        #endregion

        #region Constructor

        public LoginHandler(IUserAccountRepository userRepository, IOptions<SecurityServiceConfiguration> securitySettingsOptions)
        {
            _userRepository = userRepository;
            _securitySettings = securitySettingsOptions.Value;
        }

        #endregion

        #region Public Methods

        public async Task<TokenResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _userRepository.GetUserByCardNumber(request.LoginRequest.CardNumber);

            if (userAccount == null)
            {
                throw new ApplicationException("Tarjeta no encontrada");
            }

            CheckEnebledCard(userAccount);

            if (userAccount.Card.PIN != request.LoginRequest.Pin)
            {
                await _userRepository.AddFailedAccess(userAccount.Card.CardNumber);

                if (userAccount.FailedAccessAttempts >= _securitySettings.MaxFailedAttemptCount.Count)
                {
                    await _userRepository.LookCard(userAccount.Card.CardNumber);
                    CheckEnebledCard(userAccount);
                }

                throw new ApplicationException("PIN inválido");
            }
            // Vuelvo a cero cuando login es exitoso
            await _userRepository.ResetFailedAccessAttempts(userAccount.Card.CardNumber);

            var response = GenerateJwtToken(userAccount.Card.CardNumber);


            return response;
        }

        #endregion

        #region Private Methods

        private void CheckEnebledCard(UserAccount userAccount)
        {
            if (!userAccount.Card.Enabled)
            {
                throw new ApplicationException("Tarjeta Bloqueada");
            }
        }
        private TokenResponseDto GenerateJwtToken(string cardNumber)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_securitySettings.Jwt.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, cardNumber)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_securitySettings.ValidityTimesInMinutes.AccessToken),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenDto = new TokenResponseDto
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = token.ValidTo
            };

            return tokenDto;
        }

        #endregion
    }

}
