using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        public string PageHeaderText { get;  set; }

        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public string DepartmentId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);

            if (employeeId != 0)
            {
                PageHeaderText = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else 
            {
                PageHeaderText = "Create Employee";

                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/Bill.jpg"
                };
            }

            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentId.ToString();
        }

        protected async Task HandleValidSubmit()
        {

            if (Employee.EmployeeId != 0)
            {
                await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                await EmployeeService.CreateEmployee(Employee);
            }

            NavigationManager.NavigateTo("/");            
        }

        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            NavigationManager.NavigateTo("/");
        }
    }
}
