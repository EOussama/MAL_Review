using System;
using System.Collections.Generic;
using System.Linq;
using MAL_Reviewer_Core.exceptions;
using MAL_Reviewer_Core.interfaces;
using MAL_Reviewer_Core.models;

namespace MAL_Reviewer_Core.controllers
{
    [Serializable]
    /// <summary>
    /// The collection of review templates
    /// /// </summary>
    public class ReviewTemplatesController : ISettings
    {
        /// <summary>
        /// The default name of all review templates.
        /// </summary>
        private const string DefaultReviewTemplateName = "New review template";

        /// <summary>
        /// The maximum review templates allowed to be created.
        /// </summary>
        public static readonly short MaxReviewTemplates = 10;

        /// <summary>
        /// Contains all the template reviews loaded in the memory.
        /// </summary>
        public List<ReviewTemplateModel> ReviewTemplates { get; set; }

        /// <summary>
        /// Gets the number of review templates loaded into the memory.
        /// </summary>
        public short Count
        {
            get => (short)this.ReviewTemplates.Count;
        }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public ReviewTemplatesController() { }

        /// <summary>
        /// Gets a review template by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ReviewTemplateModel GetReviewTemplate(short index)
        {
            try
            {
                return ReviewTemplates[index];
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidReviewTemplateException(index);
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidReviewTemplateException(index);
            }
        }

        /// <summary>
        /// Adds a new review template to the collection.
        /// </summary>
        /// <param name="reviewTemplateModel"></param>
        public void AddReviewTemplate(ReviewTemplateModel reviewTemplateModel)
        {
            if (ReviewTemplates.Count <= MaxReviewTemplates)
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
        public string DeleteReviewTemplate(short index)
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
        public void UpdateReviewTemplate(short index, ReviewTemplateModel reviewTemplateModel)
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
        public string GetDuplicateName()
        {
            // Getting the number of the review template that have the same default review template name as their title.
            int nameDups = ReviewTemplates.Where(reviewTemp => reviewTemp.TemplateName.StartsWith(DefaultReviewTemplateName)).Count();

            // Constructing a review template name, (ex: defaultReviewTemplateName, defaultReviewTemplateName 1, defaultReviewTemplateName 2...).
            string reviewTemplateName = $"{ DefaultReviewTemplateName }{ (nameDups > 0 ? (" " + nameDups.ToString()) : "") }";

            return reviewTemplateName;
        }


        /// <summary>
        /// Saves the review templates in the memory.
        /// </summary>
        public void SaveSettings()
        {
            
        }

        /// <summary>
        /// Loads review templates to the memory.
        /// </summary>
        public void LoadSettings()
        {
            
        }

        /// <summary>
        /// Generate default template settings when the application first runs or
        /// when a template setting is requested.
        /// </summary>
        public void SeedSettings()
        {
            // Instanciating the review template's controller.
            ReviewTemplates = new List<ReviewTemplateModel>();

            // Adding the default “Classic MAL review”.
            AddReviewTemplate(new ReviewTemplateModel("Classic MAL review", "", true, false, DateTime.Now, DateTime.Now, new List<ReviewAspectModel>() {
                        new ReviewAspectModel("Story", "", 0),
                        new ReviewAspectModel("Art", "", 0),
                        new ReviewAspectModel("Sound", "", 0),
                        new ReviewAspectModel("Character", "", 0),
                        new ReviewAspectModel("Enjoyment", "", 0)
                    }));

            // Adding the default “Mazy MAL review”.
            AddReviewTemplate(new ReviewTemplateModel("Lazy MAL review", "", false, true, DateTime.Now, DateTime.Now, new List<ReviewAspectModel>()));
        }
    }
}
