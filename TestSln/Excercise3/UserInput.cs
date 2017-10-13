using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class UserInput
    {
        public static (byte[],byte[]) GetValidUserInput()
        {
            var recursiveService = new RecursiveService();

            Console.WriteLine(string.Concat(Enumerable.Repeat("@", 50)));
            Console.WriteLine("Console for input of Exercise 3");
            Console.WriteLine(string.Concat(Enumerable.Repeat("@", 50)));
            Console.WriteLine("Please enter byte values for first array items (comma separated) :");
            var firstArrayItems = Console.ReadLine();
            var isValid = false;
            byte[] firstArray = { };

            while (!isValid)
            {
                var result = recursiveService.ValidateArray(firstArrayItems.Split(','));
                isValid = result.IsSucceed;
                if (!isValid)
                {
                    Console.WriteLine(result.Message);
                    firstArrayItems = Console.ReadLine();
                }
                else
                {
                    firstArray = result.Data;
                }
            }

            isValid = false;
            byte[] secondArray = { };
            Console.WriteLine("Please enter byte values for second array items (comma separated) :");
            var secondArrayItems = Console.ReadLine();

            while (!isValid)
            {
                var result = recursiveService.ValidateArray(secondArrayItems.Split(','));
                isValid = result.IsSucceed;
                if (!isValid)
                {
                    Console.WriteLine(result.Message);
                    secondArrayItems = Console.ReadLine();
                }
                else
                {
                    secondArray = result.Data;
                }
            }

            return (firstArray, secondArray);
        }

        public static byte[] AddRecursive(byte[] firstArray, byte[] secondArray)
        {
            return new RecursiveService().AddRecursive(firstArray, secondArray);
        }

        public static void DisplayResult(byte[] finalArray)
        {
            Console.WriteLine("Final Array Items : {" + string.Join(",",finalArray) + "}");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
