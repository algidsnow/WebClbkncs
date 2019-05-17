using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WebAppInitializer :DropCreateDatabaseAlways<WebClubDbContext>
    {
        protected override void Seed(WebClubDbContext context)
        {
            base.Seed(context);
            context.News.Add(
                  new News { Title = "Title11111111111111111111", Content = "Content", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, UpdateBy = "32131", CreateBy = "dsadsa", prioritize = 1 });
            
            context.SaveChanges();
            context.Logins.AddOrUpdate(
                 
                 new Login { UserName = "admin1", PassWord = "admin1", Roles = 1 },
                new Login { UserName = "admin2", PassWord = "admin2", Roles = 2 }
           );
        
        }
    }
}
