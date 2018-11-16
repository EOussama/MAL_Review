using System;
using MAL_Reviewer_Core.enumerations;

namespace MAL_Reviewer_Core.models
{
    [Serializable]
    /// <summary>
    /// The review model.
    /// </summary>
    public class ReviewModel
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="targetTitle"></param>
        /// <param name="targetId"></param>
        /// <param name="targetType"></param>
        /// <param name="reviewRating"></param>
        /// <param name="created"></param>
        /// <param name="lastModified"></param>
        /// <param name="reviewTemplate"></param>
        /// <param name="reviewMethod"></param>
        public ReviewModel(string targetTitle, int targetId, EntryType targetType, double reviewRating, DateTime creationDate, DateTime lastModified, ReviewTemplateModel reviewTemplate, ReviewMethodModel reviewMethod)
        {
            TargetTitle = targetTitle;
            TargetId = targetId;
            TargetType = targetType;
            ReviewRating = reviewRating;
            CreatedDate = creationDate;
            LastModified = lastModified;
            ReviewTemplate = reviewTemplate;
            ReviewMethod= reviewMethod;
        }

        /// <summary>
        /// The review's title.
        /// </summary>
        public string TargetTitle { get; set; }

        /// <summary>
        /// The MAL ID of the Anime or Manga reviewed.
        /// </summary>
        public int TargetId { get; set; }

        /// <summary>
        /// The type of the review's target (ex; Anime or Manga).
        /// </summary>
        public EntryType TargetType { get; set; }

        /// <summary>
        /// The review's rating.
        /// </summary>
        public double ReviewRating { get; set; }

        /// <summary>
        /// The date of when the review was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date of when the review was last modified.
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// The review's template.
        /// </summary>
        public ReviewTemplateModel ReviewTemplate { get; set; }

        /// <summary>
        /// The review method of the review template.
        /// </summary>
        public ReviewMethodModel ReviewMethod { get; set; }
    }
}
