namespace MAL_Reviewer_API.models
{
    public class MangaStatsModel : models.UserModel.TargetStatsModel
    {
        public double days_read;
        public int reading;
        public int plan_to_read;
        public int reread;
        public int chapters_read;
        public int volumes_read;
    }
}
