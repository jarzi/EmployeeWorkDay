using System;
using System.Collections.Generic;
using System.Linq;
using ZadanieTestoweComAtCom.Model.Employee;
using ZadanieTestoweComAtCom.Model.Firm;
using ZadanieTestoweComAtCom.Repository;

namespace ZadanieTestoweComAtCom.Service
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Firm> GetAll(IEnumerable<Firm> firms)
        {
            var all = firms.ToList();
            foreach (var firm in all)
            {
                var employees = GetAllByFirm(firm);
                firm.Employees = employees;
            }

            return all;
        }

        private IEnumerable<Employee> GetAllByFirm(Firm firm)
        {
            var employees = firm.FirmType switch
            {
                FirmType.Firma1 => _employeeRepository.GetAll(firm).ToList(),
                FirmType.Firma2 => _employeeRepository.GetAll(firm).ToList(),
                _ => throw new ArgumentOutOfRangeException()
            };

            return employees;
        }
    }
}