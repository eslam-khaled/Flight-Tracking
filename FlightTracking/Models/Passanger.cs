using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class Passanger
    {
        [Key]
        [ForeignKey("CurrentStage")]
        public int CurrentStageId { get; set; }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public virtual CurrentStage currentStage { get; set; }
        public Plane plane { get; set; }
    }
}