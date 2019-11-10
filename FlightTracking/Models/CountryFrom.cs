﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class CountryFrom
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public List<Plane> planes { get; set; }
    }
}