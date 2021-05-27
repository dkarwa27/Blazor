using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IAppDbContext appDbContext;

        public EmployeeRepository(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
             return await Task.Run(() => AppDbContext.Employees.ToList());
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await Task.Run(() => AppDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId));
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var emp = AppDbContext.Employees.OrderByDescending(x => x.EmployeeId).FirstOrDefault();
            if (emp != null)
            {
                employee.EmployeeId = emp.EmployeeId + 1;
            }
            else
            {
                employee.EmployeeId = 1;
            }

            await Task.Run(() => AppDbContext.Employees.Add(employee));
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await Task.Run(() => AppDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId));

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                //await appDbContext.SaveChanges();

                return result;
            }

            return null;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await Task.Run(() => AppDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId));
            if (result != null)
            {
                AppDbContext.Employees.Remove(result);
                //await appDbContext.SaveChanges();
                return result;
            }

            return null;
        }
    }
}
