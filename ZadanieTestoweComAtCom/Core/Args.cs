using System;
using System.IO;
using ZadanieTestoweComAtCom.Model.Firm;

namespace ZadanieTestoweComAtCom.Core
{
    public static class Args
    {
        public static bool ValidateInput(string[] input)
        {
            try
            {
                var success = true;
                
                for (var i = 0; i < input.Length; i += 2)
                {
                    if ((input[i] == FirmType.Firma1.ToString() || input[i] == FirmType.Firma2.ToString()) && (File.Exists(input[i + 1]))) continue;
                    success = false;
                }

                return success;
            }
            catch (Exception e)
            {
                Console.WriteLine("Wprowadzono niepoprawne dane");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}