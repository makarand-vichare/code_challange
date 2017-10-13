using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Exercise2
{
    public class SafePlaceService
    {
        StreamReader file = null;
        public void ReadInputFromFile(string fileName)
        {
            file =   new StreamReader(fileName);
        }

        public string GetStringTestData()
        {
            var testData = file.ReadLine();
            var valid = (testData!= null) ? testData.IndexOf(',') >0 ? true: false: false;
            if(valid)
            {
                return testData;
            }
            else
            {
                return String.Empty;
            }
        }

        public int GetNumericTestData()
        {
            var testData = file.ReadLine();
            var valid = Int32.TryParse(testData, out int intTestData);
            if (valid)
            {
                return intTestData;
            }
            else
            {
                return -1;
            }
        }

        public ServiceResult IsValidNumberOfBombsInput(int numberOfBombs)
        {
            var result = new ServiceResult { IsSucceed = true };
            if(numberOfBombs > AppConstants.MAX_BOMBS_VALUE || numberOfBombs < AppConstants.MIN_BOMBS_VALUE)
            {
                result.IsSucceed = false;
                result.Message = string.Format(AppConstants.INPUT_INVALID_BOMBS_VALUE, AppConstants.MIN_BOMBS_VALUE, AppConstants.MAX_BOMBS_VALUE);
            }

            return result;
        }

        public ServiceResult IsValidMaxTestCasesAllowedInput(int numberOfTestCases)
        {
            var result = new ServiceResult { IsSucceed = true };
            if (numberOfTestCases > AppConstants.MAX_TESTCASES_VALUE || numberOfTestCases < AppConstants.MIN_TESTCASES_VALUE)
            {
                result.IsSucceed = false;
                result.Message = string.Format(AppConstants.INPUT_INVALID_TEXTCASES_VALUE, AppConstants.MIN_TESTCASES_VALUE, AppConstants.MAX_TESTCASES_VALUE);
            }

            return result;
        }

        public ServiceResult<int[]> GetValidBombCordinates(string coOrdinates)
        {
            var result = new ServiceResult<int[]>();
            try
            {
                var splitArray = coOrdinates.Split(',').Select(int.Parse).ToArray();

                if(splitArray[0]>AppConstants.MAX_XPOSITION_VALUE || splitArray[1] > AppConstants.MAX_YPOSITION_VALUE || splitArray[2] > AppConstants.MAX_ZPOSITION_VALUE)
                {
                    result.Message = string.Format(AppConstants.INPUT_INVALID_COORDINATES_VALUE, AppConstants.MAX_XPOSITION_VALUE, AppConstants.MAX_YPOSITION_VALUE, AppConstants.MAX_ZPOSITION_VALUE);
                    return result;
                }

                result.Data = splitArray;
                result.IsSucceed = true;
            }
            catch
            {
            }

            return result;
        }

        public BombSafePlace FindSafePlace(BombSafePlace bombSafePlace)
        {
            var safePlaceKey = string.Empty;
            double maxDistanceForSafePlace = 0;
            for(int xCoOrdinate=0; xCoOrdinate<AppConstants.MAX_XPOSITION_VALUE;xCoOrdinate++)
            {
                for (int yCoOrdinate = 0; yCoOrdinate < AppConstants.MAX_YPOSITION_VALUE; yCoOrdinate++)
                {
                    for (int zCoOrdinate = 0; zCoOrdinate < AppConstants.MAX_ZPOSITION_VALUE; zCoOrdinate++)
                    {
                       var maxDistance = GetMinDistanceFromAllBombsForEachPoint(xCoOrdinate, yCoOrdinate, zCoOrdinate, bombSafePlace);

                        if (maxDistanceForSafePlace < maxDistance)
                        {
                            maxDistanceForSafePlace = maxDistance;
                            safePlaceKey = string.Format("{0}-{1}-{2}", xCoOrdinate, yCoOrdinate, zCoOrdinate);
                        }
                    }
                }
            }

            var safePlaceCoOrdinates = GetCurrentPositionCoOrdinate(safePlaceKey);
            bombSafePlace.SafeXPostion = safePlaceCoOrdinates[0];
            bombSafePlace.SafeYPostion = safePlaceCoOrdinates[1];
            bombSafePlace.SafeZPostion = safePlaceCoOrdinates[2];
            bombSafePlace.SafeDistance = maxDistanceForSafePlace;
            return bombSafePlace;
        }

        private int[] GetCurrentPositionCoOrdinate(string key)
        {
            var coOrdinateArray = key.Split('-').Select(int.Parse).ToArray();
            return coOrdinateArray;
        }

        private double GetMinDistanceFromAllBombsForEachPoint(int xPlacePosition, int yPlacePosition, int zPlacePosition, BombSafePlace bombSafePlace)
        {
            double minDistance = 0;
            for (int bombIndex = 0; bombIndex < bombSafePlace.NumberOfBombs; bombIndex++)
            {
                var distance = CalculateDistance(xPlacePosition, bombSafePlace.XPositions[bombIndex], yPlacePosition, bombSafePlace.YPositions[bombIndex], zPlacePosition, bombSafePlace.ZPositions[bombIndex]);
                if(distance<minDistance)
                {
                    minDistance = distance;
                }
            }
            return minDistance;
        }

        private double CalculateDistance(int x1, int x2, int y1, int y2, int z1, int z2)
        {
           return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) + (z1 - z2) * (z1 - z2));
        }
    }
}
