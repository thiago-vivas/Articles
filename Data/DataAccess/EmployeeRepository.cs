using Data.DataAccess.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private NorthwindContext DbContext { get; }
        public EmployeeRepository(NorthwindContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this.DbContext.Employees;
        }
        public Employee GetEmployeeById(int employeeId)
        {
            return this.DbContext.Employees.FirstOrDefault(x => x.EmployeeId.Equals(employeeId));
        }
        public Employee CreateEmployee(Employee employee)
        {
            this.DbContext.Employees.Add(employee);
            this.DbContext.SaveChanges();

            return employee;
        }
    }
}
