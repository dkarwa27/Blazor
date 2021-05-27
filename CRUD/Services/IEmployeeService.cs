using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);

        Task UpdateEmployee(Employee updatedEmployee);

        Task CreateEmployee(Employee newEmployee);

        Task DeleteEmployee(int id);
    }
}
