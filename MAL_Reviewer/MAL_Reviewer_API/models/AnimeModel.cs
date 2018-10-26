using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAL_Reviewer_API.models
{
    public class AnimeModel : TargetModel
    {
        public bool airing { get; set; }
        public int? episodes { get; set; }
    }
}
