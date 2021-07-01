using System;

namespace ZadanieTestoweComAtCom.Model.Employee
{
    public class WorkDay
    {
        public int EmployeeId { get; init; }
        public DateTime Date { get; init; }
        public TimeSpan TimeLeave { get; init; }
        public TimeSpan TimeEnter { get; init; }
    }
}