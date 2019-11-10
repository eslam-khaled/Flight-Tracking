using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class Plane
    {
        public int ID { get; set; }
        public string AirLine { get; set; }
        public double ArrivalTime { get; set; }
        public string ArrivalHall { get; set; }
        public string ArrivalBulding { get; set; }
    }
}