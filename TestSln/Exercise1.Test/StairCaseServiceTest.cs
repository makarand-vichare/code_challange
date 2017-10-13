using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise1.Test
{
    [TestClass]
    public class StairCaseServiceTest
    {
        private StairCaseService stairCaseService = new StairCaseService();

        [TestMethod]
        public void ValidateFlights_WhenValidFlight_ThenSuccess()
        {
            //Arrange
            string[] flights = { "15" };

            // Act
            var result = stairCaseService.ValidateFlights(flights);

            //Assert

            Assert.IsTrue(result.IsSucceed);
            Assert.AreEqual(15, result.Data[0]);
        }

        [TestMethod]
        public void ValidateFlights_WhenValidMultipleFlights_ThenSuccess()
        {
            //Arrange
            string[] flights = { "15", "15" };

            // Act
            var result = stairCaseService.ValidateFlights(flights);

            //Assert

            Assert.IsTrue(result.IsSucceed);
            Assert.AreEqual(15, result.Data[1]);
        }

        [TestMethod]
        public void ValidateFlights_WhenInValidFlight_ThenFails()
        {
            //Arrange
            string[] flights = { "fifteen" };

            // Act
            var result = stairCaseService.ValidateFlights(flights);

            //Assert

            Assert.IsFalse(result.IsSucceed);
        }

        [TestMethod]
        public void ValidateFlights_WhenInValidFlights_ThenFails()
        {
            //Arrange
            string[] flights = { "fifteen","15" };

            // Act
            var result = stairCaseService.ValidateFlights(flights);

            //Assert

            Assert.IsFalse(result.IsSucceed);
        }

        [TestMethod]
        public void ValidateStepsPerStride_WhenValidInput_ThenSuccess()
        {
            //Arrange
            string stepsPerStride = "2";

            // Act
            var result = stairCaseService.ValidateStepsPerStride(stepsPerStride);

            //Assert

            Assert.IsTrue(result.IsSucceed);
            Assert.AreEqual(2, result.Data);
        }

        [TestMethod]
        public void ValidateStepsPerStride_WhenInValidInput_ThenFails()
        {
            //Arrange
            string stepsPerStride = "two";

            // Act
            var result = stairCaseService.ValidateStepsPerStride(stepsPerStride);

            //Assert

            Assert.IsFalse(result.IsSucceed);
        }

        [TestMethod]
        public void ValidateStepsPerStride_WhenEmptyInput_ThenFails()
        {
            //Arrange
            string stepsPerStride = "";

            // Act
            var result = stairCaseService.ValidateStepsPerStride(stepsPerStride);

            //Assert

            Assert.IsFalse(result.IsSucceed);
        }

        [TestMethod]
        public void CalculateStepsForTop_WhenValidInputSingleFlight_ThenReturnValidResult()
        {
            //Arrange
            var stairCase = new StairCase { Flights = new int[] { 15 }, StepsPerStride = 2, TurnAroundSride = 2 };

            // Act
            stairCaseService.CalculateStepsForTop(stairCase);

            //Assert

            Assert.AreEqual(8, stairCase.TotalStepsRequired);
        }

        [TestMethod]
        public void CalculateStepsForTop_WhenValidInputTwoFlight_ThenReturnValidResult()
        {
            //Arrange
            var stairCase = new StairCase { Flights = new int[] { 15,15 }, StepsPerStride = 2, TurnAroundSride = 2 };

            // Act
            stairCaseService.CalculateStepsForTop(stairCase);

            //Assert

            Assert.AreEqual(18, stairCase.TotalStepsRequired);
        }

        [TestMethod]
        public void CalculateStepsForTop_WhenValidInputMultipleFlight_ThenReturnValidResult()
        {
            //Arrange
            var stairCase = new StairCase { Flights = new int[] { 5, 11, 9, 13, 8, 30, 14 }, StepsPerStride = 3, TurnAroundSride = 2 };

            // Act
            stairCaseService.CalculateStepsForTop(stairCase);

            //Assert

            Assert.AreEqual(44, stairCase.TotalStepsRequired);
        }

    }
}
