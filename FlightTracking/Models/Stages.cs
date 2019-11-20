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

        [Required(ErrorMessage = "pleas enter  stage name")]
        [Display(Name = "current stage")]
        public string StageName { get; set; }

        
        [Display(Name = "Estimated Time")]
        public int EstimatedTime { get; set; }

        [Display(Name = "Extra Time")]
        
        public int? ExtraTime { get; set; }

        [Required(ErrorMessage ="some thing wrong?!please enter passenger data again")]
        public List<Passanger> passangers { get; set; }
        public string Picture { get; set; }
    }
}