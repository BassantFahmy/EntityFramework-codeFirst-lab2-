using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int FK_DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Book> Books { get; set; }

        public Car Car { get; set; }
    }
}
