using Application.Managers.Interfaces;
using Data.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }
    }
}
