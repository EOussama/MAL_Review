using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAL_Reviewer_API.models
{
    public class TargetModel
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public float? score { get; set; }
        public int? rank { get; set; }
        public string synopsis { get; set; }
    }
}
