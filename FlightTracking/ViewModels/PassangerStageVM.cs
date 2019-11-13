using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightTracking.Models;

namespace FlightTracking.ViewModels
{
    public class PassangerStageVM
    {
        public  Passanger passanger { get; set; }
        public IEnumerable<Stages> stages { get; set; }

       
    }
}