using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment4.Models
{
    public class v_variants
    {
        public int VehicleId { get; set; }
        public int ModelYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
    public class chartdatafromDB { 
   
    public string MakeModel { get; set; }
        public decimal datafield { get; set; }
        public string color { get; set; }
        public int counts { get; set; }
    }
}
