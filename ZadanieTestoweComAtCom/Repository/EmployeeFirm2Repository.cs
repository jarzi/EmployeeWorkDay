using System;
using System.Collections.Generic;
using System.Linq;
using ZadanieTestoweComAtCom.Core;
using ZadanieTestoweComAtCom.Model.Employee;
using ZadanieTestoweComAtCom.Model.Firm;

namespace ZadanieTestoweComAtCom.Repository
{
    public class EmployeeFirm2Repository : IEmployeeRepository
    {
        private readonly IEmployeeParser _employeeParser;

        public EmployeeFirm2Repository(IEmployeeParser employeeParser)
        {
            _employeeParser = employeeParser;
        }

        public IEnumerable<Employee> GetAll(Firm firm)
        {
            if (firm.FirmType != FirmType.Firma2) return Enumerable.Empty<Employee>();
         
            var employees = new List<Employee>();
            
            var prevEmployeeId = 0;
            var currentEmployee = new Employee {WorkDays = new List<WorkDay>()};
            
            const int pairNumber = 2;
            var file = FileHelper.OpenAndRead(firm.ReportEmployeesFilePath).ToList();

            try
            {
                for (var i = 0; i < file.Count; i += pairNumber)
                {
                    var currentEmployeeId = _employeeParser.GetEmployeeId(file[i]);
                    if (currentEmployeeId == prevEmployeeId || prevEmployeeId == 0)
                    {
                        var workDay = new WorkDay
                        {
                            EmployeeId = _employeeParser.GetEmployeeId(file[i]),
                            Date = _employeeParser.GetEmployeeDate(file[i]),
                            TimeEnter = _employeeParser.GetTimeEnter(file[i]),
                            TimeLeave = _employeeParser.GetTimeLeave(file[i + 1])
                        };
                        currentEmployee.WorkDays.Add(workDay);
                    }
                    else
                    {
                        currentEmployee = new Employee(currentEmployeeId) {WorkDays = new List<WorkDay>()};
                        employees.Add(currentEmployee);
                    }
                    prevEmployeeId = currentEmployeeId;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArgumentException();
            }

            return employees;
        }
    }
}