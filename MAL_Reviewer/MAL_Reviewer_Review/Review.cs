using System;
using System.Collections.Generic;
using MAL_Reviewer_Review.models;

namespace MAL_Reviewer_Review
{
    /// <summary>
    /// The global review helper that manages everything to do with reviews in the memory.
    /// </summary>
    public static class Review
    {
        /// <summary>
        /// Contains all the template reviews in memory.
        /// </summary>
        public static List<ReviewTemplateModel> ReviewTemplates;

        /// <summary>
        /// Loads review template into the memory.
        /// </summary>
        public static void LoadReviewTemplates()
        {
            ReviewTemplates = new List<ReviewTemplateModel>
            {
                new ReviewTemplateModel("MAL review", "", true, false, DateTime.Now, DateTime.Now, new List<ReviewAspectModel>() {
                        new ReviewAspectModel("Story", "", 0),
                        new ReviewAspectModel("Art", "", 0),
                        new ReviewAspectModel("Sound", "", 0),
                        new ReviewAspectModel("Character", "", 0),
                        new ReviewAspectModel("Enjoyment", "", 0)
                    }),
                new ReviewTemplateModel("Lazy review", "", true, false, DateTime.Now, DateTime.Now, new List<ReviewAspectModel>()),
                new ReviewTemplateModel("Super long review, really.", "", true, true, DateTime.Now, DateTime.Now, new List<ReviewAspectModel>() {
                        new ReviewAspectModel("Story", "", 0),
                        new ReviewAspectModel("Art", "", 0),
                        new ReviewAspectModel("Sound", "", 0),
                        new ReviewAspectModel("Character", "", 0),
                        new ReviewAspectModel("Humor", "", 0),
                        new ReviewAspectModel("Enjoyment", "", 0),
                        new ReviewAspectModel("Darkness", "", 0),
                        new ReviewAspectModel("Bordome", "", 0),
                        new ReviewAspectModel("Side notes", "", 0)
                    }),
                new ReviewTemplateModel("Lazy review, but very long, even longer than the other one, it makes it look pathetic.", "", false, true, DateTime.Now, DateTime.Now, new List<ReviewAspectModel>() {
                    new ReviewAspectModel("Sound", "", 0),
                    new ReviewAspectModel("Art", "", 0)
                }),
            };
        }
    }
}
