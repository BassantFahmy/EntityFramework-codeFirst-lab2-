namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationEmpBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmpBooks",
                c => new
                    {
                        FK_EmployeeId = c.Int(nullable: false),
                        FK_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FK_EmployeeId, t.FK_BookId })
                .ForeignKey("dbo.Employee", t => t.FK_EmployeeId)
                .ForeignKey("dbo.Books", t => t.FK_BookId)
                .Index(t => t.FK_EmployeeId)
                .Index(t => t.FK_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpBooks", "FK_BookId", "dbo.Books");
            DropForeignKey("dbo.EmpBooks", "FK_EmployeeId", "dbo.Employee");
            DropIndex("dbo.EmpBooks", new[] { "FK_BookId" });
            DropIndex("dbo.EmpBooks", new[] { "FK_EmployeeId" });
            DropTable("dbo.EmpBooks");
            DropTable("dbo.Books");
        }
    }
}
