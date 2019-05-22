using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
 
    public class WebClubDbContext:DbContext
    {
        public WebClubDbContext():base("WebMvcSqlServer")
        {
            Database.SetInitializer(new WebAppInitializer());
         
        }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Member> Members { get; set; }
    }
}
