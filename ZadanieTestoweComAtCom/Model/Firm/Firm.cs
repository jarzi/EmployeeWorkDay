using System.Collections.Generic;

namespace ZadanieTestoweComAtCom.Model.Firm
{
    public class Firm
    {
        public FirmType FirmType { get; }
        public string ReportEmployeesFilePath { get; }
        public IEnumerable<Employee.Employee> Employees { get; set; }

        public Firm(FirmType firmType, string reportEmployeesFilePath)
        {
            FirmType = firmType;
            ReportEmployeesFilePath = reportEmployeesFilePath.Trim().ToLower();
        }
    }
}