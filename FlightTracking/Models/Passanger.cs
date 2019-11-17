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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        [ForeignKey("plane")]
        public int? PassangerPlaneId { get; set; }
        public virtual Plane plane { get; set; }
        [ForeignKey("Stages")]
        public int? PassangerStageId { get; set; }
        public virtual Stages Stages { get; set; }
    

    }
}