namespace MAL_Reviewer_API.models.ListEntryModel
{
    public class AnimelistEntryModel : ListEntryModel
    {
        public short? watching_status { get; set; }
        public short? watched_episodes { get; set; }
        public short? total_episodes { get; set; }
    }
}
