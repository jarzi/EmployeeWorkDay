using System;
using System.Collections.Generic;
using System.Diagnostics;
using ZadanieTestoweComAtCom.Model.Firm;

namespace ZadanieTestoweComAtCom.Core
{
    public static class UiHelper
    {
        public static void ShowHelp()
        {
            Console.WriteLine(Process.GetCurrentProcess().ProcessName + ".exe"+ " typFirmy sciezkaDoPlikuZRaportem typFirmyN sciezkaDoPlikuZRaportemN ..." +
                              " Przykładowe użycie: " + Process.GetCurrentProcess().ProcessName + ".exe" + " Firma1 rcp1.csv Firma2 rcp2.csv");
        }

        public static void ShowErrorMessage()
        {
            Console.WriteLine("Wprowadzono niepoprawne dane");
        }
        
        public static void ShowFirmsData(IEnumerable<Firm> firms)
        {
            foreach (var firm in firms)
            {
                foreach (var firmEmployee in firm.Employees)
                {
                    Console.WriteLine("Pracownik");
                    foreach (var workDay in firmEmployee.WorkDays)
                    {
                        Console.WriteLine("\tId: " + workDay.EmployeeId);
                        Console.WriteLine("\t" + workDay.Date.ToString("yyyy-MM-dd"));
                        Console.WriteLine("\t" + workDay.TimeEnter);
                        Console.WriteLine("\t" + workDay.TimeLeave);
                    }
                }
            }
        }
    }
}