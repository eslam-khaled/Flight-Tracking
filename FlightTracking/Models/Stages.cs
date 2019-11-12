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
        public string StageName { get; set; }
        public int EstimatedTime { get; set; }
        public int? ExtraTime { get; set; }
        public List<Passanger> passangers { get; set; }
    }
}