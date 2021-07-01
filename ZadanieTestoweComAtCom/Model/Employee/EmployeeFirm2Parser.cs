using System;
using ZadanieTestoweComAtCom.Core;

namespace ZadanieTestoweComAtCom.Model.Employee
{
    public class EmployeeFirm2Parser : IEmployeeParser
    {
        private const ushort EmployeeTimeEnterLeaveIndex = 2;
        private const ushort EmployeeSymbolIndex = 3;
        private const string EmployeeEnterSymbol = "WE";
        private const string EmployeeLeaveSymbol = "WY";
        
        public TimeSpan GetTimeEnter(string csv)
        {
            return csv.Split(FileHelper.Separator)[EmployeeSymbolIndex] != EmployeeEnterSymbol ? new TimeSpan() : TimeHelper.DateTimeToTimeSpan(TimeHelper.GetHourMinutesTimeFromCsv(csv, EmployeeTimeEnterLeaveIndex));
        }

        public TimeSpan GetTimeLeave(string csv)
        {
            return csv.Split(FileHelper.Separator)[EmployeeSymbolIndex] != EmployeeLeaveSymbol ? new TimeSpan() : TimeHelper.DateTimeToTimeSpan(TimeHelper.GetHourMinutesTimeFromCsv(csv, EmployeeTimeEnterLeaveIndex));
        }
    }
}