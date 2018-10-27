using System.Collections.Generic;

namespace MAL_Reviewer_Review.models
{
    class ReviewTemplate
    {
        private List<ReviewAspect> _templateAspects;
        private ReviewMethod _templateMethod;
        private string _templateName;

        public ReviewTemplate(string templateName, List<ReviewAspect> templateAspects, ReviewMethod templateMethod)
        {
            this.templateName = templateName;
            this.templateAspects = templateAspects;
            this.templateMethod = templateMethod;
        }

        public string templateName { get => _templateName; set => _templateName = value; }
        internal List<ReviewAspect> templateAspects { get => _templateAspects; set => _templateAspects = value; }
        internal ReviewMethod templateMethod { get => _templateMethod; set => _templateMethod = value; }
    }
}
