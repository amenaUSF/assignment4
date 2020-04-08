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

        public DbSet<v_year> years { get; set; }
        public DbSet<v_make> makes { get; set; }
        public DbSet<v_model> models { get; set; }
        public DbSet<v_id> ids { get; set; }
        public DbSet<safetyratings> safety { get; set; }
    }

}
