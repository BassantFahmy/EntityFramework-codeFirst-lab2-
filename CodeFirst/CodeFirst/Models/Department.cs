﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Department
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
