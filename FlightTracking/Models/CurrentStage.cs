using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class CurrentStage
    {
        public int ID { get; set; }
        //Reference for the other tables to allow one-to-one relationship
        public virtual Customs Customs { get; set; }
        public virtual Inspecting inspecting { get; set; }
        public virtual Luggage luggage { get; set; }
        public virtual Papers papers { get; set; }
    }
}