namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRealationBookCover : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cover");
            AlterColumn("dbo.Cover", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Cover", "Id");
            CreateIndex("dbo.Cover", "Id");
            AddForeignKey("dbo.Cover", "Id", "dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cover", "Id", "dbo.Books");
            DropIndex("dbo.Cover", new[] { "Id" });
            DropPrimaryKey("dbo.Cover");
            AlterColumn("dbo.Cover", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cover", "Id");
        }
    }
}
