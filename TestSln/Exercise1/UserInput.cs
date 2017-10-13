using System;
using System.Linq;

namespace Exercise1
{
    public class UserInput
    {
        public static StairCase GetValidUserInput()
        {
            StairCaseService stairCaseService = new StairCaseService();

            Console.WriteLine(string.Concat(Enumerable.Repeat("@", 50)));
            Console.WriteLine("Console for input of Exercise 1");
            Console.WriteLine(string.Concat(Enumerable.Repeat("@", 50)));
            Console.WriteLine("Please enter Flights List (comma separated) :");
            var flights = Console.ReadLine();
            var isValidFlight = false;
            int[] validFlights = { };

            while (!isValidFlight)
            {
                var result = stairCaseService.ValidateFlights(flights.Split(','));
                isValidFlight = result.IsSucceed;
                if (!isValidFlight)
                {
                    Console.WriteLine(result.Message);
                    flights = Console.ReadLine();
                }
                else
                {
                    validFlights = result.Data;
                }
            }

            var isValidStepsPerStride = false;
            int validStepsPerStride = 0;
            Console.WriteLine("Please enter Steps Per Stride :");

            var stepsPerStride = Console.ReadLine();

            while (!isValidStepsPerStride)
            {
                var result = stairCaseService.ValidateStepsPerStride(stepsPerStride);
                isValidStepsPerStride = result.IsSucceed;
                if (!isValidStepsPerStride)
                {
                    Console.WriteLine(result.Message);
                    stepsPerStride = Console.ReadLine();
                }
                else
                {
                    validStepsPerStride = result.Data;
                }
            }

            return stairCaseService.GetValidStairCase(validFlights, validStepsPerStride).Data;
        }

        public static StairCase CalculateStepsForTop(StairCase stairCase)
        {
            return new StairCaseService().CalculateStepsForTop(stairCase);
        }

        public static void DisplayResult(StairCase stairCase)
        {
            Console.WriteLine("Total Steps Required : " + stairCase.TotalStepsRequired);
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
