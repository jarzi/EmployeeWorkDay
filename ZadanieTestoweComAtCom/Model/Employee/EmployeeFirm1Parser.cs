using System;
using ZadanieTestoweComAtCom.Core;

namespace ZadanieTestoweComAtCom.Model.Employee
{
    public class EmployeeFirm1Parser : IEmployeeParser
    {
        private const ushort EmployeeTimeEnterIndex = 2;
        private const ushort EmployeeTimeLeaveIndex = 3;
        
        public TimeSpan GetTimeEnter(string csv)
        {
            return TimeHelper.DateTimeToTimeSpan(TimeHelper.GetTimeFromCsv(csv, EmployeeTimeEnterIndex));
        }

        public TimeSpan GetTimeLeave(string csv)
        {
            return TimeHelper.DateTimeToTimeSpan(TimeHelper.GetTimeFromCsv(csv, EmployeeTimeLeaveIndex));
        }
    }
}