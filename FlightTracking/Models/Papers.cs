﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    public class Papers
    {
        public int ID { get; set; }
        public int StageName { get; set; }
        public double EstimatedTime { get; set; }
        public double ExtraTime { get; set; }

    }
}