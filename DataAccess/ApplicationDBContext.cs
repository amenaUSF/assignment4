using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment4.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment4.data_access_folder
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }


        //tables to get data from the api since our api requires too many sequential hits, we grabbed data over different sessions
        public DbSet<v_year> years { get; set; }
        public DbSet<v_make> makes { get; set; }
        public DbSet<v_model> models { get; set; }
        public DbSet<v_id> ids { get; set; }
        public DbSet<safetyratings> safety { get; set; }
        //tables that will actually run the website
        public DbSet<vehicle_years> Vehicle_Years { get; set; }
        public DbSet<vehicle_makes> Vehicle_Makes { get; set; }
        public DbSet<vehicle_models> Vehicle_Models { get; set; }
        public DbSet<vehicle_variants> Vehicle_Variants{ get; set; }
        public DbSet<vehicle_safetyratings> Vehicle_Safetyratings{ get; set; }
        public DbSet<usercomments> UserReviews { get; set; }

    }

}
