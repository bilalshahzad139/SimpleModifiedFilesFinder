using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSyncApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String startingPath = System.Configuration.ConfigurationManager.AppSettings["startingPath"];
            String copiedTo = System.Configuration.ConfigurationManager.AppSettings["copiedTo"];

            if (!Directory.Exists(startingPath))
            {
                System.Console.WriteLine("Invalid starting path {0}:", startingPath);
                System.Console.ReadKey();
            }

            DateTime startDT;
            DateTime endDT = DateTime.Now;

            String startDateStr = System.Configuration.ConfigurationManager.AppSettings["startDate"];

            if(DateTime.TryParse(startDateStr, out startDT) == false)
            {
                System.Console.WriteLine("Invalid start date {0}:", startDateStr);
                System.Console.ReadKey();
            }

            String endDateStr = System.Configuration.ConfigurationManager.AppSettings["endDate"];
            if(endDateStr != "")
            {
                if (DateTime.TryParse(endDateStr, out endDT) == false)
                {
                    System.Console.WriteLine("Invalid end date {0}:", endDateStr);
                    System.Console.ReadKey();
                }
            }

            var result = ModifiedFileFinder.FindAndCopyTo(startingPath, copiedTo, startDT, endDT, true);

            foreach(var f in result)
            {
                Console.WriteLine(f);
            }

            System.Console.ReadKey();

        }

        
    }
}
