namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKtoCity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            RenameColumn(table: "dbo.Cities", name: "Country_Id", newName: "CountryId");
            AlterColumn("dbo.Cities", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "CountryId");
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            AlterColumn("dbo.Cities", "CountryId", c => c.Int());
            RenameColumn(table: "dbo.Cities", name: "CountryId", newName: "Country_Id");
            CreateIndex("dbo.Cities", "Country_Id");
            AddForeignKey("dbo.Cities", "Country_Id", "dbo.Countries", "Id");
        }
    }
}
