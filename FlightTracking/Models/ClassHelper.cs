using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightTracking.Models
{
    
    public class ClassHelper
    {
        static ApplicationDbContext context = new ApplicationDbContext();

        public static int TotalTime(int? id)
        {
            var SumTime= context.Stages.Where(x => x.StageID >= id).Sum(c => c.EstimatedTime);
            return SumTime;
        }
    }
}