using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class Stages
    {
        [Key]
        public int StageID { get; set; }
        [Display(Name ="Stage Name")]
        public string StageName { get; set; }
        [Display(Name = "Estimated Time")]
        public int EstimatedTime { get; set; }
        [Display(Name = "Extra Time")]
        public int? ExtraTime { get; set; }
        public List<Passanger> passangers { get; set; }
    }
}