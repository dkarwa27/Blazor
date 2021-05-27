using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Api.Models
{
    public interface IAppDbContext
    {
        public static List<Employee> Employees { get; set; }

        public static List<Department> Departments { get; set; }
    }
}
