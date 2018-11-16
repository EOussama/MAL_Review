using System;

namespace MAL_Reviewer_Review.exceptions
{
    /// <summary>
    /// Exception that asserts the maximum review templates allowed to be created.
    /// </summary>
    public class MaximumReviewTemplatesException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MaximumReviewTemplatesException() :base() { }
    }
}
