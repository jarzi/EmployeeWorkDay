using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ZadanieTestoweComAtCom.Core
{
    public static class FileHelper
    {
        public const char Separator = ';';
        
        public static IEnumerable<string> OpenAndRead(string filenamePath)
        {
            try
            {
                return File.ReadLines(filenamePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Enumerable.Empty<string>();
        }
    }
}