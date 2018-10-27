namespace MAL_Reviewer_Review.models
{
    class ReviewMethod
    {
        private byte _reviewScale;
        private bool _decimalUse;

        public ReviewMethod(byte reviewScale, bool decimalUse)
        {
            this.reviewScale = reviewScale;
            this.decimalUse = decimalUse;
        }

        public byte reviewScale { get => _reviewScale; set => _reviewScale = value; }
        public bool decimalUse { get => _decimalUse; set => _decimalUse = value; }
    }
}
