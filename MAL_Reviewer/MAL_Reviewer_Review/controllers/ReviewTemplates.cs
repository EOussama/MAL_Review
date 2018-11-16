using System;
using System.Collections.Generic;
using System.Linq;
using MAL_Reviewer_Review.exceptions;
using MAL_Reviewer_Review.models;

namespace MAL_Reviewer_Review.controllers
{
    /// <summary>
    /// The collection of review templates
    /// /// </summary>
    public static class ReviewTemplatesController
    {
        /// <summary>
        /// The default name of every review template.
        /// </summary>
        private const string defaultReviewTemplateName = "New review template";

        /// <summary>
        /// The maximum review templates allowed to be created.
        /// </summary>
        public static readonly short MaxReviewTemplates = 10;

        /// <summary>
        /// Contains all the template reviews in memory.
        /// </summary>
        public static List<ReviewTemplateModel> ReviewTemplates { get; set; }

        /// <summary>
        /// Gets a review template by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ReviewTemplateModel GetReviewTemplate(short index)
        {
            try
            {
                return ReviewTemplates[index];
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a new review template to the collection.
        /// </summary>
        /// <param name="reviewTemplateModel"></param>
        public static void AddReviewTemplate(ReviewTemplateModel reviewTemplateModel)
        {
            if (ReviewTemplates.Count < MaxReviewTemplates)
            {
                ReviewTemplates.Add(reviewTemplateModel);
            }
            else
            {
                throw new MaximumReviewTemplatesException();
            }
        }

        /// <summary>
        /// Deletes a review template.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string DeleteReviewTemplate(short index)
        {
            string revTempName = string.Empty;

            try
            {
                revTempName = ReviewTemplates[index].TemplateName;
                ReviewTemplates.RemoveAt(index);
            }
            catch (Exception)
            {
                throw;
            }

            return revTempName;
        }

        /// <summary>
        /// Updates a review template.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="reviewTemplateModel"></param>
        public static void UpdateReviewTemplate(short index, ReviewTemplateModel reviewTemplateModel)
        {
            try
            {
                ReviewTemplates[index] = reviewTemplateModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Appends the proper number in a string to avoid duplicating the review template names.
        /// </summary>
        /// <returns></returns>
        public static string GetDuplicateName()
        {
            // Getting the number of the review template that have the same default review template name as their title.
            int nameDups = ReviewTemplates.Where(reviewTemp => reviewTemp.TemplateName.StartsWith(defaultReviewTemplateName)).Count();

            // Constructing a review template name, (ex: defaultReviewTemplateName, defaultReviewTemplateName 1, defaultReviewTemplateName 2...).
            string reviewTemplateName = $"{ defaultReviewTemplateName }{ (nameDups > 0 ? (" " + nameDups.ToString()) : "") }";

            return reviewTemplateName;
        }
    }
}
