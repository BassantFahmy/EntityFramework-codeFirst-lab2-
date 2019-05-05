namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookCity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmpBooks", "FK_BookId", "dbo.Books");
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Books", "Id");
            CreateIndex("dbo.Books", "Id");
            AddForeignKey("dbo.Books", "Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.EmpBooks", "FK_BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpBooks", "FK_BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "Id", "dbo.Cities");
            DropIndex("dbo.Books", new[] { "Id" });
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "Id");
            AddForeignKey("dbo.EmpBooks", "FK_BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
