namespace CodeFirst
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        // Your context has been configured to use a 'ModelContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CodeFirst.ModelContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelContext' 
        // connection string in the application configuration file.
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .HasKey(d => d.DeptId)
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Employee>()
               .ToTable("Employee")
               .Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(50);
            modelBuilder.Entity<Department>()
             .HasMany(d => d.Employees)
             .WithRequired(e => e.Department)
             .HasForeignKey(e => e.FK_DepartmentId)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
            .HasMany(e => e.Books)
            .WithMany(b => b.Employees)
            .Map(m => m.ToTable("EmpBooks").
            MapLeftKey("FK_EmployeeId")
            .MapRightKey("FK_BookId"));

            /*one to one optional*/
            modelBuilder.Entity<City>()
                .HasOptional(c => c.Book)
                .WithRequired(b => b.City);
            /*create Table Cover*/
            modelBuilder.Entity<Cover>()
                .ToTable("Cover")
                .Property(c => c.Code)
                .HasMaxLength(50)
                .IsRequired();
            /*one to one required*/
            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Cover).
                WithRequiredPrincipal(c => c.Book);
              
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}