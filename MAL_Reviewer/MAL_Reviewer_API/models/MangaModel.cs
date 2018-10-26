namespace MAL_Reviewer_API.models
{
    public class MangaModel : TargetModel
    {
        public bool publishing { get; set; }
        public int? volumes { get; set; }
        public int? chapters { get; set; }
    }
}
