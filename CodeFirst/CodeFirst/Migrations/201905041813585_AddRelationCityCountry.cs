namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationCityCountry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Country_Id", c => c.Int());
            CreateIndex("dbo.Cities", "Country_Id");
            AddForeignKey("dbo.Cities", "Country_Id", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropColumn("dbo.Cities", "Country_Id");
        }
    }
}
