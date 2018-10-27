namespace MAL_Reviewer_Review.models
{
    class ReviewAspect
    {
        private string _aspectName;
        private string _aspectReview;
        private double _aspectRating;

        public ReviewAspect(string aspectName, string aspectReview, double aspectRating)
        {
            this.aspectName = aspectName;
            this.aspectReview = aspectReview;
            this.aspectRating = aspectRating;
        }

        public string aspectName { get => _aspectName; set => _aspectName = value; }
        public string aspectReview { get => _aspectReview; set => _aspectReview = value; }
        public double aspectRating { get => _aspectRating; set => _aspectRating = value; }
    }
}
