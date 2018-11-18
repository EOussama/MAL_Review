using System;

namespace MAL_Reviewer_Core.exceptions
{
    /// <summary>
    /// The exception thrown when trying to access an invalid review templates.
    /// </summary>
    public class InvalidReviewTemplateException : Exception
    {
        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public InvalidReviewTemplateException() { }

        /// <summary>
        /// The message thrown when the exception is invoked.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Invalid review template";
        }
    }
}
