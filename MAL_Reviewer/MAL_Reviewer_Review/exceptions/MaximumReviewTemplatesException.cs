using System;
using MAL_Reviewer_Core.controllers;

namespace MAL_Reviewer_Core.exceptions
{
    [Serializable]
    /// <summary>
    /// Exception that asserts the maximum review templates allowed to be created.
    /// </summary>
    public class MaximumReviewTemplatesException : Exception
    {
        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public MaximumReviewTemplatesException()
        {
        }

        /// <summary>
        /// The exception return message.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"The maximum ({ ReviewTemplatesController.MaxReviewTemplates }) review templates allowed has been reached!";
        }
    }
}
