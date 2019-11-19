using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class PassangerSearch
    {
 	public string PicturePath{ get; set; }
        public string PassangerName { get; set; }
        public string PassangerNationality { get; set; }
        public string StageName { get; set; }
        public int? StageExtraTime { get; set; }
        public int StageEstimatedTime { get; set; }
    }
}