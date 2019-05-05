namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRealationCityUSer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserCities", "City_Id", "dbo.Cities");
            DropIndex("dbo.UserCities", new[] { "User_Id" });
            DropIndex("dbo.UserCities", new[] { "City_Id" });
            DropTable("dbo.UserCities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserCities",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        City_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.City_Id });
            
            CreateIndex("dbo.UserCities", "City_Id");
            CreateIndex("dbo.UserCities", "User_Id");
            AddForeignKey("dbo.UserCities", "City_Id", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserCities", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
