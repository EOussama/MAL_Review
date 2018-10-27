namespace MAL_Reviewer_Review.models
{
    class Review
    {
        private ReviewTemplate _reviewTemplate;
        private string _targetTitle;
        private string _reviewIntro;
        private double _reviewRating;
        private bool _introUse;

        public Review(string targetTitle, string reviewIntro, double reviewRating, bool introUse, ReviewTemplate reviewTemplate)
        {
            this.targetTitle = targetTitle;
            this.reviewIntro = reviewIntro;
            this.reviewRating = reviewRating;
            this.introUse = introUse;
            this.reviewTemplate = reviewTemplate;
        }

        public string targetTitle { get => _targetTitle; set => _targetTitle = value; }
        public string reviewIntro { get => _reviewIntro; set => _reviewIntro = value; }
        public double reviewRating { get => _reviewRating; set => _reviewRating = value; }
        public bool introUse { get => _introUse; set => _introUse = value; }
        internal ReviewTemplate reviewTemplate { get => _reviewTemplate; set => _reviewTemplate = value; }
    }
}
