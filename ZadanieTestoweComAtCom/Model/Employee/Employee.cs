using System.Collections.Generic;

namespace ZadanieTestoweComAtCom.Model.Employee
{
    public class Employee
    {
        public int EmployeeId { get; }
        public IList<WorkDay> WorkDays { get; init; }

        public Employee()
        {
        }
        
        public Employee(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}