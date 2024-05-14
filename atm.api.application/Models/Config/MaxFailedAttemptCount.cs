using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.api.application.Models.Config
{
    public class MaxFailedAttemptCount
    {
        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public MaxFailedAttemptCount() { }

        /// <summary>
        /// Contructor with parameters.
        /// </summary> 
        /// <param name="passwordChange">Maximum failed password change attempts.</param>
        public MaxFailedAttemptCount(int count)
        {
            Count = count;
        }

        #endregion

        #region Properties
                  
        public int Count { get; set; }

        #endregion
    }
}
