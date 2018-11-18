using System;

namespace MAL_Reviewer_Core.models
{
    [Serializable]
    /// <summary>
    /// Review method model.
    /// </summary>
    public class ReviewMethodModel
    {
        #region Properties

        /// <summary>
        /// The scale of the review's rating (5, 10, 50...).
        /// </summary>
        public byte ReviewScaling { get; set; }

        /// <summary>
        /// Whether or not to use decimal numbers in the rating (ex; 8.63, 6.13...).
        /// </summary>
        public bool UseDecimal { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="reviewScale"></param>
        /// <param name="decimalUse"></param>
        public ReviewMethodModel(byte reviewScale, bool decimalUse)
        {
            this.ReviewScaling = reviewScale;
            this.UseDecimal = decimalUse;
        }

        #endregion
    }
}
