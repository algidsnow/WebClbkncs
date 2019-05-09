using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WebClubDbContext:DbContext
    {
        public WebClubDbContext():base("name=WebAppMySql")
        {
            Database.SetInitializer(new WebAppInitializer());
         
        }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    }
}
