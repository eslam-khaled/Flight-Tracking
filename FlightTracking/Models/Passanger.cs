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

        [Required(ErrorMessage = "please enter  passenger name")]
        [StringLength(100, ErrorMessage = "The name must be maximum 100 and minimum 6 characters long.", MinimumLength = 6)]
        [Display(Name = "passenger name")]
        public string Name { get; set; }

        [Display(Name ="Nationality")]
        [Required(ErrorMessage = "please enter  passenger nationality")]
        public string Nationality { get; set; }

        [ForeignKey("plane")]
        public int? PassangerPlaneId { get; set; }
        public virtual Plane plane { get; set; }
        [ForeignKey("Stages")]
        public int? PassangerStageId { get; set; }
        public virtual Stages Stages { get; set; }
    

    }
}