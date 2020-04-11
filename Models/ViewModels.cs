using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment4.Models
{
    public class SearchView
    {
        //list to display options in the view for check your car ratings
        public SelectList Years { get; set; }
        public SelectList Makes { get; set; }
        public SelectList Models { get; set; }
        //search strings that will store finalized search values
        public string yearsearch { get; set; }
        public string makesearch { get; set; }
        public string modelsearch { get; set; }
        //final model with complete vehicle info 
        public IQueryable<safetyratingsview> safetyrating { get; set; }
    }

    public class safetyratingsview
    {
        public string OverallRating { get; set; }
        public string OverallFrontCrashRating { get; set; }
        public string FrontCrashDriversideRating { get; set; }
        public string FrontCrashPassengersideRating { get; set; }
        public string OverallSideCrashRating { get; set; }
        public string SideCrashDriversideRating { get; set; }
        public string SideCrashPassengersideRating { get; set; }
        public string RolloverRating { get; set; }
        public string RolloverPossibility { get; set; }
        public string SidePoleCrashRating { get; set; }
        public string ComplaintsCount { get; set; }
        public string RecallsCount { get; set; }
        public int ModelYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string VehicleDescription { get; set; }
    }

}
