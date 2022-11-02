using Application.Managers.Interfaces;
using Application.Models;
using AutoMapper;
using Data.DataAccess.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeRepository EmployeeRepository { get; }
        private IMapper Mapper { get; }
        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.EmployeeRepository = employeeRepository;
            this.Mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var response = this.EmployeeRepository.GetEmployees();

            return Mapper.Map<IEnumerable<EmployeeDto>>(response);
        }
        public EmployeeDto GetEmployeeById(int employeeId)
        {
            var response = this.EmployeeRepository.GetEmployeeById(employeeId);
            return Mapper.Map<EmployeeDto>(response);
        }
        public EmployeeDto CreateEmployee(EmployeeDto employee)
        {
            var entity = Mapper.Map<Employee>(employee);
            var response = this.EmployeeRepository.CreateEmployee(entity);

            return Mapper.Map<EmployeeDto>(response);
        }
    }
}
