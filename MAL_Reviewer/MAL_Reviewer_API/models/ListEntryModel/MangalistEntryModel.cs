namespace MAL_Reviewer_API.models.ListEntryModel
{
    public class MangalistEntryModel : ListEntryModel
    {
        public short? reading_status { get; set; }
        public short? read_chapters { get; set; }
        public short? read_volumes { get; set; }
        public short? total_chapters { get; set; }
        public short? total_volumes { get; set; }
    }
}
