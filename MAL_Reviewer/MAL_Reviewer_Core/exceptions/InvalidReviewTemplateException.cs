using System;

namespace MAL_Reviewer_Core.exceptions
{
    /// <summary>
    /// The exception thrown when trying to access an invalid review templates.
    /// </summary>
    public class InvalidReviewTemplateException : Exception
    {
        #region Fields

        /// <summary>
        /// The review template's index that raised the exception.
        /// </summary>
        private readonly short ReviewTemplateIndex = -1;

        #endregion

        #region Constructors

        /// <summary>
        /// Constuctor with message.
        /// </summary>
        /// <param name="reviewTemplateIndex"></param>
        public InvalidReviewTemplateException(short reviewTemplateIndex) : base()
        {
            this.ReviewTemplateIndex = reviewTemplateIndex;
        }

        #endregion

        #region Public method

        /// <summary>
        /// The message thrown when the exception is invoked.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"The review template with the index of { this.ReviewTemplateIndex } doesn't exist.";
        }

        #endregion
    }
}
