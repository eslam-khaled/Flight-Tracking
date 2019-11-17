using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightTracking.Models;

namespace FlightTracking.ViewModels
{
    public class PassangerStageVM
    {
        public List<Passanger> passanger { get; set; }
        public Stages stages { get; set; }


    }
}