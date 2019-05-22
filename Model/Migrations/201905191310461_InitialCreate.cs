namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        PassWord = c.String(maxLength: 50),
                        Roles = c.Int(),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        idMember = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        position = c.String(),
                        age = c.Int(nullable: false),
                        address = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        UrlPresentMember = c.String(),
                        prioritize = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMember);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(),
                        CreateDate = c.String(),
                        CreateBy = c.String(),
                        UpdateDate = c.String(),
                        UpdateBy = c.String(),
                        UrlRepresent = c.String(),
                        shortContent = c.String(),
                        status = c.Int(nullable: false),
                        prioritize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.News");
            DropTable("dbo.Members");
            DropTable("dbo.Logins");
        }
    }
}
