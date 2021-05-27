using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Api.Models
{
    public class AppDbContext : IAppDbContext
    {
        public static List<Employee> Employees { get; set; }

        public static List<Department> Departments { get; set; }

        static AppDbContext()
        {
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "Bill",
                LastName = "Gates",
                Email = "bill.gates@gmail.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/Bill.jpg"
            };

            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Sheryl",
                LastName = "Wilson",
                Email = "sheryl.wilson@gmail.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Female,
                DepartmentId = 2,
                PhotoPath = "images/Sheryl.jpg"
            };

            Employees = new List<Employee> { e1, e2 };

            Department d1 = new Department
            {
                DepartmentId = 1,
                DepartmentName = "Admin"
            };

            Department d2 = new Department
            {
                DepartmentId = 2,
                DepartmentName = "HR"
            };

            Departments = new List<Department> { d1, d2 };
        }
    }
}
