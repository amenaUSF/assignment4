    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment4.Models
{
    public class usercomments
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string comments { get; set; }

    }

    public class vehicle_years
    {
        [Key]
        public int year_id { get; set; }
        public int ModelYear { get; set; }
        List<safetyratings> safetyrating { get; set; }

    }
    public class vehicle_makes
    {
        [Key]
        public int make_id { get; set; }
        public string Make { get; set; }
        List<safetyratings> safetyrating { get; set; }
    }
    public class vehicle_models
    {
        [Key]
        public int model_id { get; set; }
        public string Model { get; set; }
        List<safetyratings> safetyrating { get; set; }
    }
    public class vehicle_safetyratings
    {
        [Key]
        public int VehicleId { get; set; }
        public string VehicleDescription { get; set; }
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
        //foreign keys for year model and make
        [ForeignKey("years")]
        public int year_id { get; set; }
        public virtual vehicle_years years { get; set; }
        [ForeignKey("makes")]
        public int make_id { get; set; }
        public virtual vehicle_makes makes { get; set; }
        [ForeignKey("models")]
        public int model_id { get; set; }
        public virtual vehicle_models models { get; set; }


    }


}
