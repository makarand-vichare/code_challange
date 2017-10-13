using Exercise3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArrays = UserInput.GetValidUserInput();
            var result = UserInput.AddRecursive(inputArrays.Item1, inputArrays.Item2);
            UserInput.DisplayResult(result);
        }
    }
}
