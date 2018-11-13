using System;
using System.Collections.Generic;

namespace MAL_Reviewer_Review.models
{
    /// <summary>
    /// Review template model.
    /// </summary>
    class ReviewTemplate
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="templateReviewIntro"></param>
        /// <param name="useIntro"></param>
        /// <param name="addTLDR"></param>
        /// <param name="creationDate"></param>
        /// <param name="templateAspects"></param>
        /// <param name="templateReviewMethod"></param>
        public ReviewTemplate(string templateName, string templateReviewIntro, bool useIntro, bool addTLDR, DateTime creationDate, List<ReviewAspect> templateAspects, ReviewMethod templateReviewMethod)
        {
            TemplateName = templateName;
            TemplateReviewIntro = templateReviewIntro;
            UseIntro = useIntro;
            AddTLDR = addTLDR;
            CreationDate = creationDate;
            TemplateAspects = templateAspects;
            TemplateReviewMethod = templateReviewMethod;
        }

        /// <summary>
        /// The name of the review template.
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// The review template's intro.
        /// </summary>
        public string TemplateReviewIntro { get; set; }

        /// <summary>
        /// Whether or not to use an intro for the review.
        /// </summary>
        public bool UseIntro { get; set; }

        /// <summary>
        /// Whether or not to add a tl;dr section.
        /// </summary>
        public bool AddTLDR { get; set; }

        /// <summary>
        /// The date of when the review template was created.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// The list of the aspects of the review template (ex; Art, Story, Sound...).
        /// </summary>
        public List<ReviewAspect> TemplateAspects { get; set; }

        /// <summary>
        /// The review method of the review template.
        /// </summary>
        public ReviewMethod TemplateReviewMethod { get; set; }
    }
}
