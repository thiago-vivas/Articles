using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Managers.Interfaces
{
    public interface IEmployeeManager
    {
        EmployeeDto CreateEmployee(EmployeeDto employee);
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployeeById(int employeeId);
    }
}
