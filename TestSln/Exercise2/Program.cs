using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug\","") + "inputfile.txt";
             UserConsole.RunTestCaseFromFile(path);
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
