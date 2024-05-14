using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.application.Models.Config
{
    public class ValidityTimesInMinutes
    {
        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public ValidityTimesInMinutes() { }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="accessToken">Validity time in minutes of the access token.</param>
        /// <param name="refreshToken">Validity time in minutes of the refresh token.</param> 
        public ValidityTimesInMinutes(int accessToken,
            int refreshToken,
            int passwordChange,
            int emailConfirmation)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken; 
        }

        #endregion

        #region Properties

        public int AccessToken { get; set; }

        public int RefreshToken { get; set; }
          
        #endregion
    }
}
