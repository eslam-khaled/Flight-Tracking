using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class Inspecting
    {
        [Key]
        [ForeignKey("currentStage")]
        public int CurrentStageId { get; set; }
        public int ID { get; set; }
        public int StageName { get; set; }
        public double EstimatedTime { get; set; }
        public double ExtraTime { get; set; }
        //Reference for the other tables to allow one-to-one relationship
        public virtual CurrentStage currentStage { get; set; }

    }
}