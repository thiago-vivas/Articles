using Application.Managers.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeManager EmployeeManager { get; }
        public EmployeeController(IEmployeeManager employeeManager)
        {
            this.EmployeeManager = employeeManager;
        }
        [HttpGet]
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return EmployeeManager.GetEmployees();
        }
        [HttpGet("{employeeId:int}")]
        public EmployeeDto GetEmployeeById(int employeeId)
        {
            return EmployeeManager.GetEmployeeById(employeeId);
        }
        [HttpPost]
        public EmployeeDto PostEmployee([FromBody] EmployeeDto employee)
        {
            return EmployeeManager.CreateEmployee(employee);
        }
    }
}
