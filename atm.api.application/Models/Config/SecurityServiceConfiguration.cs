
namespace atm.api.application.Models.Config
{
    public class SecurityServiceConfiguration
    {
        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public SecurityServiceConfiguration() { }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="jwt">JWT settings.</param>
        /// <param name="validityTimesInMinutes">Validity times settings.</param>
        /// <param name="maxFailedAttemptCount">Maximum failed attempt count settings.</param>
        public SecurityServiceConfiguration(JwtConfiguration jwt,
            ValidityTimesInMinutes validityTimesInMinutes,
            MaxFailedAttemptCount maxFailedAttemptCount)
        {
            Jwt = jwt;
            ValidityTimesInMinutes = validityTimesInMinutes;
            MaxFailedAttemptCount = maxFailedAttemptCount;
        }

        #endregion

        #region Properties

        public JwtConfiguration Jwt { get; set; }

        public ValidityTimesInMinutes ValidityTimesInMinutes { get; set; }

        public MaxFailedAttemptCount MaxFailedAttemptCount { get; set; }

        #endregion
    }

}
