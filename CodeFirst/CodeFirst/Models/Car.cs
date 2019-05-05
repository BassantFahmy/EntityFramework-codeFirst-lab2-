using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Car
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }
        public int BrandName { get; set; }

        
        public Employee Employee { get; set; }

    }
}
