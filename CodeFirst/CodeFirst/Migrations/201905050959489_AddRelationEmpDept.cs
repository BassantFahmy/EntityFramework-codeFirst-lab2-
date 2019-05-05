namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationEmpDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "FK_DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "Department_DeptId", c => c.Int());
            CreateIndex("dbo.Employee", "Department_DeptId");
            AddForeignKey("dbo.Employee", "Department_DeptId", "dbo.Department", "DeptId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Department_DeptId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_DeptId" });
            DropColumn("dbo.Employee", "Department_DeptId");
            DropColumn("dbo.Employee", "FK_DepartmentId");
        }
    }
}
