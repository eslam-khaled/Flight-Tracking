using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class CountryFrom
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "invalid country ,country must be no more 50 charchter length")]
        public string Country { get; set; }
        public List<Plane> planes { get; set; }
    }
}