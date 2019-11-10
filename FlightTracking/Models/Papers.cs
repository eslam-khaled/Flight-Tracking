using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class Papers
    {
        [Key]
        [ForeignKey("currentStage")]
        public int CurrentStageId { get; set; }
        public int ID { get; set; }
        public int StageName { get; set; }
        public double EstimatedTime { get; set; }
        public double ExtraTime { get; set; }
        public virtual CurrentStage currentStage { get; set; }

    }
}