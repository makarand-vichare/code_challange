using System;
using System.Collections.Generic;

namespace Exercise1
{
    public class StairCaseService
    {
        public ServiceResult<StairCase> GetValidStairCase(int[] flights,int stepsPerStride)
        {
            var result = new ServiceResult<StairCase>();
            result.IsSucceed = true;
            result.Data = new StairCase { Flights = flights , StepsPerStride = stepsPerStride , TurnAroundSride = AppConstants.TURN_AROUND_STEPS };
            return result;
        }

        public ServiceResult<int[]> ValidateFlights(string[] flights)
        {
            var result = new ServiceResult<int[]>();
            try
            {
                if (flights == null || flights.Length <=0)
                {
                    result.Message = AppConstants.FLIGHTS_INPUT_INVALID;
                    return result;
                }

                if (flights.Length > AppConstants.MAX_FLIGHTS_ALLOWED)
                {
                    result.Message = string.Format(AppConstants.FLIGHTS_INPUT_EXCEEDED_MAX_FLIGHTS_ALLOWED, AppConstants.MAX_FLIGHTS_ALLOWED);
                    return result;
                }

                var flightsList = new List<int>();
                var isValid = false;
                foreach (var flight in flights)
                {
                    isValid =  Int32.TryParse(flight, out int intFlight);
                    if(!isValid)
                    {
                        result.Message = AppConstants.FLIGHTS_INPUT_NOT_INTEGER;
                        break;
                    }

                    if(intFlight > AppConstants.MAX_FLIGHTS_OF_STAIRS || intFlight < AppConstants.MIN_FLIGHTS_OF_STAIRS)
                    {
                        result.Message = string.Format(AppConstants.FLIGHTS_INPUT_EXCEEDED_MAX_FLIGHTS_OF_STAIRS_ALLOWED, AppConstants.MIN_FLIGHTS_OF_STAIRS,AppConstants.MAX_FLIGHTS_OF_STAIRS);
                        break;
                    }

                    flightsList.Add(intFlight);
                }

                if(!isValid)
                {
                    return result;
                }

                result.Data = flightsList.ToArray();
                result.IsSucceed = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public ServiceResult<int> ValidateStepsPerStride(string stepsPerStride)
        {
            var result = new ServiceResult<int>();
            try
            {
                if (string.IsNullOrEmpty(stepsPerStride))
                {
                    result.Message = AppConstants.STEPPERSTRIDE_INPUT_INVALID;
                    return result;
                }

                var isValid = Int32.TryParse(stepsPerStride, out int intStepsPerStride);

                if (!isValid)
                {
                    result.Message = AppConstants.STEPPERSTRIDE_INPUT_NOT_INTEGER;
                    return result;
                }

                if (intStepsPerStride > AppConstants.MAX_STEP_PER_STRIDE || intStepsPerStride < AppConstants.MIN_STEP_PER_STRIDE)
                {
                    result.Message = string.Format(AppConstants.STEPPERSTRIDE_INPUT_EXCEEDED_MAX_STEP_PER_STRIDE_ALLOWED, AppConstants.MIN_STEP_PER_STRIDE, AppConstants.MAX_STEP_PER_STRIDE);
                    return result;
                }

                result.IsSucceed = true;
                result.Data = intStepsPerStride;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public StairCase CalculateStepsForTop(StairCase stairCase)
        {
            var totalRequiredSteps = 0;
            foreach(var flight in stairCase.Flights)
            {
                totalRequiredSteps += (flight / stairCase.StepsPerStride);
                if(flight % stairCase.StepsPerStride > 0)
                {
                    totalRequiredSteps++;
                }
            }

            totalRequiredSteps += (stairCase.Flights.Length - 1) * stairCase.TurnAroundSride;

            stairCase.TotalStepsRequired = totalRequiredSteps;
            return stairCase;
        }

    }
}
