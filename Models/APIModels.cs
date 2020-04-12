using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment4.Models
{
    public class YearResult
    {
        public List<v_year> Results;
    }
    public class v_year
    {
        [Key]
        public int year_id { get; set; }
        public int ModelYear { get; set; }
        public List<safetyratings> safetyrating { get; set; }
    }

    public class MakeResult
    {
        public List<v_make> Results;
    }
    public class v_make
    {
        public int ModelYear { get; set; }
        [Key]
        public int make_id { get; set; }
        public string Make { get; set; }
        public List<safetyratings> safetyrating { get; set; }
    }
    public class ModelResult
    {
        public List<v_model> Results;
    }
    public class v_model
    {
        public int ModelYear { get; set; }
        public string Make { get; set; }
        [Key]
        public int model_id { get; set; }
        public string Model { get; set; }
        public List<safetyratings> safetyrating { get; set; }
    }

    public class VidResult
    {
        public List<v_id> Results;
    }
    public class v_id
    {
        [Key]
        public int veh_id { get; set; }
        public string VehicleDescription { get; set; }
        public int VehicleId { get; set; }
    }
    public class SafetyRatingsResult
    {
        public List<safetyratings> Results { get; set; }
    }

    public class safetyratings
    {
        [Key]
        public int veh_id { get; set; }
        public int VehicleId { get; set; }
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

        //foreign keys for year model and make
        [ForeignKey("years")]
        public int year_id { get; set; }
        public virtual v_year years { get; set; }
        [ForeignKey("makes")]
        public int make_id { get; set; }
        public virtual v_make makes { get; set; }
        [ForeignKey("models")]
        public int model_id { get; set; }
        public virtual v_model models { get; set; }


    }

}
