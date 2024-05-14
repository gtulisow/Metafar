using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.application.Models.Config
{
    public class JwtConfiguration
    {
        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public JwtConfiguration() { }

        /// <summary>
        /// Contructor with parameters.
        /// </summary>
        /// <param name="validAudience">A URL to validate audience.</param>
        /// <param name="validIssuer">A URL to validate issuer.</param>
        /// <param name="secret">The encryption secret.</param>
        public JwtConfiguration(string validAudience, string validIssuer, string secret)
        {
            ValidAudience = validAudience;
            ValidIssuer = validIssuer;
            Secret = secret;
        }

        #endregion

        #region Properties

        public string ValidAudience { get; set; }

        public string ValidIssuer { get; set; }

        public string Secret { get; set; }

        #endregion
    }

}
