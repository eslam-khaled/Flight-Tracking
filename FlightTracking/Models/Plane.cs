using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class Plane
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter passenger airlin!! ")]
        [MaxLength(50)]
        public string AirLine { get; set; }


        [Required(ErrorMessage = "Please enter passenger arrival time!!")]
        public double ArrivalTime { get; set; }


        [Required(ErrorMessage = "Please enter passenger arrival hall!!")]
        public string ArrivalHall { get; set; }


        [Required(ErrorMessage = "Please enter passenger arrival building!!")]
        public string ArrivalBulding { get; set; }


        public List<Passanger> passangers { get; set; }


        
        [MinLength(4, ErrorMessage = "complete country name  ")]
        [MaxLength(50, ErrorMessage = "make sure of countryname with no repeat of charchters ")]
        public CountryFrom countryFrom { get; set; }
    }
}