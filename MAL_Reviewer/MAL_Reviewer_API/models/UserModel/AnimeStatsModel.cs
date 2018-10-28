namespace MAL_Reviewer_API.models
{
    public class AnimeStatsModel : models.UserModel.TargetStatsModel
    {
        public double? days_watched;
        public int? watching;
        public int? plan_to_watch;
        public int? rewatched;
        public int? episodes_watched;
    }
}
