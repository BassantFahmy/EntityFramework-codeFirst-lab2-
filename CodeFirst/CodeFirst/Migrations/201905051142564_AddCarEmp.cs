namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarEmp : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cars");
            AlterColumn("dbo.Cars", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Cars", "Id");
            CreateIndex("dbo.Cars", "Id");
            AddForeignKey("dbo.Cars", "Id", "dbo.Employee", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Id", "dbo.Employee");
            DropIndex("dbo.Cars", new[] { "Id" });
            DropPrimaryKey("dbo.Cars");
            AlterColumn("dbo.Cars", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cars", "Id");
        }
    }
}
