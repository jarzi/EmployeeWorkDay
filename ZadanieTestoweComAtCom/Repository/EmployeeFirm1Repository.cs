using System;
using System.Collections.Generic;
using System.Linq;
using ZadanieTestoweComAtCom.Core;
using ZadanieTestoweComAtCom.Model.Employee;
using ZadanieTestoweComAtCom.Model.Firm;

namespace ZadanieTestoweComAtCom.Repository
{
    public class EmployeeFirm1Repository : IEmployeeRepository
    {
        private readonly IEmployeeParser _employeeParser;

        public EmployeeFirm1Repository(IEmployeeParser employeeParser)
        {
            _employeeParser = employeeParser;
        }

        public IEnumerable<Employee> GetAll(Firm firm)
        {
            if (firm.FirmType != FirmType.Firma1) return Enumerable.Empty<Employee>();
         
            var employees = new List<Employee>();
            
            var prevEmployeeId = 0;
            var currentEmployee = new Employee {WorkDays = new List<WorkDay>()};

            try
            {
                foreach (var employeeCsv in FileHelper.OpenAndRead(firm.ReportEmployeesFilePath))
                {
                    var currentEmployeeId = _employeeParser.GetEmployeeId(employeeCsv);
                    if (currentEmployeeId == prevEmployeeId || prevEmployeeId == 0)
                    {
                        var workDay = new WorkDay
                        {
                            EmployeeId = _employeeParser.GetEmployeeId(employeeCsv),
                            Date = _employeeParser.GetEmployeeDate(employeeCsv),
                            TimeEnter = _employeeParser.GetTimeEnter(employeeCsv),
                            TimeLeave = _employeeParser.GetTimeLeave(employeeCsv)
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