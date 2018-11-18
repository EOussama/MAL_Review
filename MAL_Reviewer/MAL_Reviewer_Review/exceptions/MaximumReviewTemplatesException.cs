﻿using System;
using MAL_Reviewer_Core.controllers;

namespace MAL_Reviewer_Core.exceptions
{
    [Serializable]
    /// <summary>
    /// Exception that asserts the maximum review templates allowed to be created.
    /// </summary>
    public class MaximumReviewTemplatesException : Exception
    {
        #region Constructor

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public MaximumReviewTemplatesException() { }

        #endregion

        #region Public methods

        /// <summary>
        /// The message thrown when the exception is invoked.
        /// </summary>
        /// <returns></returns>
        /// 
        public override string ToString()
        {
            return $"The maximum ({ ReviewTemplatesController.MaxReviewTemplates }) review templates allowed has been reached!";
        }
        
        #endregion
    }
}
