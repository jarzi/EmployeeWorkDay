using System;
using ZadanieTestoweComAtCom.Core;

namespace ZadanieTestoweComAtCom.Model.Employee
{
    public interface IEmployeeParser
    {
        private const ushort EmployeeIdIndex = 0;
        private const ushort EmployeeDateIndex = 1;

        public int GetEmployeeId(string csv)
        {
            return int.Parse(csv.Split(FileHelper.Separator)[EmployeeIdIndex]);
        }
        
        public DateTime GetEmployeeDate(string csv)
        {
            return TimeHelper.GetDateTimeFromCsv(csv, EmployeeDateIndex);
        }

        public TimeSpan GetTimeEnter(string csv);
        public TimeSpan GetTimeLeave(string csv);
    }
}