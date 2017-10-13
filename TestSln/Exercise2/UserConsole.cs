using System;
using System.Linq;
using System.Text;

namespace Exercise2
{
    public class UserConsole
    {
        public static void RunTestCaseFromFile(string fileName)
        {
            var safePlaceService = new SafePlaceService();

            Console.WriteLine(string.Concat(Enumerable.Repeat("@", 80)));
            Console.WriteLine("Console for input of Exercise 2");
            Console.WriteLine(string.Concat(Enumerable.Repeat("@", 80)));
            Console.WriteLine("Reading Test data from file");

            safePlaceService.ReadInputFromFile(fileName);

            var totalTestCases = safePlaceService.GetNumericTestData();

            var result = safePlaceService.IsValidMaxTestCasesAllowedInput(totalTestCases);
            if (!result.IsSucceed)
            {
                Console.WriteLine("Error Message : " + result.Message);
            }

            Console.WriteLine("Total test cases to be executed : " + totalTestCases);

            for (int index = 0; index < totalTestCases; index++)
            {
                var numberOfBombs = safePlaceService.GetNumericTestData();
                result = safePlaceService.IsValidNumberOfBombsInput(numberOfBombs);
                if (result.IsSucceed)
                {
                    var bombSafePlace = new BombSafePlace { NumberOfBombs = numberOfBombs };
                    bombSafePlace.XPositions = new int[numberOfBombs];
                    bombSafePlace.YPositions = new int[numberOfBombs];
                    bombSafePlace.ZPositions = new int[numberOfBombs];

                    for (int bombIndex = 0; bombIndex < numberOfBombs; bombIndex++)
                    {
                        var coOrdinateResult = safePlaceService.GetValidBombCordinates(safePlaceService.GetStringTestData());
                        if (result.IsSucceed)
                        {
                            bombSafePlace.XPositions[bombIndex] = coOrdinateResult.Data[0];
                            bombSafePlace.YPositions[bombIndex] = coOrdinateResult.Data[1];
                            bombSafePlace.ZPositions[bombIndex] = coOrdinateResult.Data[2];
                        }
                        else
                        {
                            Console.WriteLine("Error Message : " + result.Message);
                            break;
                        }
                    }

                    var testedBombSafePlace = safePlaceService.FindSafePlace(bombSafePlace);
                    DisplayResult(testedBombSafePlace);
                }
                else
                {
                    Console.WriteLine("Error Message : " + result.Message);
                }
            }
        }

        public static void DisplayResult(BombSafePlace bombSafePlace)
        {
            Console.WriteLine("Test Details : ");
            Console.WriteLine("Number of Bombs : " + bombSafePlace.NumberOfBombs);
            var bombPositions = new StringBuilder();

            for (int bombIndex = 0; bombIndex < bombSafePlace.NumberOfBombs; bombIndex++)
            {
                bombPositions.AppendFormat("[{0},{1},{2}]   ", bombSafePlace.XPositions[bombIndex], bombSafePlace.YPositions[bombIndex], bombSafePlace.ZPositions[bombIndex]);
            }
            Console.WriteLine(bombPositions.ToString());
            Console.WriteLine(string.Format("Position of Safe Place : [{0},{1},{2}]", bombSafePlace.SafeXPostion, bombSafePlace.SafeYPostion, bombSafePlace.SafeZPostion));
            Console.WriteLine(string.Concat(Enumerable.Repeat("@", 80)));
        }
    }
}
