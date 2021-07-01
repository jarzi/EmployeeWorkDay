using System;
using System.Collections.Generic;
using ZadanieTestoweComAtCom.Model.Employee;
using ZadanieTestoweComAtCom.Model.Firm;
using ZadanieTestoweComAtCom.Repository;
using ZadanieTestoweComAtCom.Service;

namespace ZadanieTestoweComAtCom.Core
{
    public static class App
    {
        public static void Start(string[] args)
        {
            if (args.Length == 0 || args[0] == "-help")
            {
                UiHelper.ShowHelp();
                return;
            }

            if (Args.ValidateInput(args))
            {
                var firmsList1 = new List<Firm>();
                var firmsList2 = new List<Firm>();
                
                AddFirms(args, firmsList1, firmsList2);

                var firm1Service = new EmployeeService(new EmployeeFirm1Repository(new EmployeeFirm1Parser()));
                var firm2Service = new EmployeeService(new EmployeeFirm2Repository(new EmployeeFirm2Parser()));

                var firms1 = firm1Service.GetAll(firmsList1);
                var firms2 = firm2Service.GetAll(firmsList2);
                
                Console.WriteLine("Wyświetlić dane? y\\n [y]");
                var show = Console.ReadLine();

                if (string.IsNullOrEmpty(show) || show == "y")
                {
                    UiHelper.ShowFirmsData(firms1);
                    UiHelper.ShowFirmsData(firms2);
                }
            }
            else
            {
                UiHelper.ShowErrorMessage();
            }
        }

        private static void AddFirms(string[] args, IList<Firm> firmsList1, IList<Firm> firmsList2)
        {
            for (var i = 0; i < args.Length; i += 3)
            {
                if (args[i] == FirmType.Firma1.ToString())
                {
                    firmsList1.Add(new Firm(FirmType.Firma1, args[i + 1]));
                }
                else if (args[i] == FirmType.Firma2.ToString())
                {
                    firmsList2.Add(new Firm(FirmType.Firma2, args[i + 1]));
                }
            }
        }
    }
}