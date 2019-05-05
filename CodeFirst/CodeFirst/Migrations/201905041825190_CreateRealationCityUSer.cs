namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRealationCityUSer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCities",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        City_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.City_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.City_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCities", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.UserCities", "User_Id", "dbo.Users");
            DropIndex("dbo.UserCities", new[] { "City_Id" });
            DropIndex("dbo.UserCities", new[] { "User_Id" });
            DropTable("dbo.UserCities");
        }
    }
}
