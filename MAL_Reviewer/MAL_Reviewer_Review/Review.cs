using System;
using System.Collections.Generic;
using MAL_Reviewer_Review.models;
using MAL_Reviewer_Review.controllers;

namespace MAL_Reviewer_Review
{
    /// <summary>
    /// The global review helper that manages everything to do with reviews in the memory.
    /// </summary>
    public static class Review
    {
        /// <summary>
        /// Loads review template into the memory.
        /// </summary>
        public static void LoadReviewTemplates()
        {
            // Instanciating the review template's controller.
            ReviewTemplatesController.ReviewTemplates = new List<ReviewTemplateModel>();

            // Adding the default “Classic MAL review”.
            ReviewTemplatesController.AddReviewTemplate(new ReviewTemplateModel("Classic MAL review", "", true, false, DateTime.Now, DateTime.Now, new List<ReviewAspectModel>() {
                        new ReviewAspectModel("Story", "", 0),
                        new ReviewAspectModel("Art", "", 0),
                        new ReviewAspectModel("Sound", "", 0),
                        new ReviewAspectModel("Character", "", 0),
                        new ReviewAspectModel("Enjoyment", "", 0)
                    }));

            // Adding the default “Mazy MAL review”.
            ReviewTemplatesController.AddReviewTemplate(new ReviewTemplateModel("Lazy MAL review", "", false, true, DateTime.Now, DateTime.Now, new List<ReviewAspectModel>()));
        }
    }
}
