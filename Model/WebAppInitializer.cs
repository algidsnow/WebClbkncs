using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WebAppInitializer : DropCreateDatabaseIfModelChanges<WebClubDbContext>
    {
        protected override void Seed(WebClubDbContext context)
        {
            base.Seed(context);
            context.News.AddOrUpdate(
                  new News { Title = "Title11111111111111111111", Content = "Content", CreateDate = DateTime.Now, prioritize = 1 },
                 new News { Title = "Title2222222222222222222222", Content = "Content2", CreateDate = DateTime.Now, prioritize = 2 }
            );
            context.Logins.AddOrUpdate(
                 
                 new Login { UserName = "admin1", PassWord = "admin1", Roles = 1 },
                new Login { UserName = "admin2", PassWord = "admin2", Roles = 2 }
           );
            context.SaveChanges();
        }
    }
}
