namespace MAL_Reviewer_API.models.ListEntryModel
{
    public class ListEntryModel
    {
        public string title { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string type { get; set; }
        public byte? score { get; set; }
    }
}
