using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IAppDbContext appDbContext;

        public DepartmentRepository(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await Task.Run(() => AppDbContext.Departments.FirstOrDefault(d => d.DepartmentId == departmentId));
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await Task.Run(() => AppDbContext.Departments);
        }
    }
}
