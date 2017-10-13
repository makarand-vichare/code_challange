using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Exercise3.Test
{
    [TestFixture]
    public class RecursiveServiceTest
    {
        private RecursiveService stairCaseService = new RecursiveService();

        public static IEnumerable<TestCaseData> Add_Source
        {
            get
            {
                yield return new TestCaseData(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 }).Returns(new byte[] { 2, 2, 2 });
                yield return new TestCaseData(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 }).Returns(new byte[] { 1, 2, 0 });
                yield return new TestCaseData(new byte[] { 255, 1, 1 }, new byte[] { 0, 0, 1 }).Returns(new byte[] { 255, 1, 2 });
            }
        }

        [Test]
        [TestCaseSource("Add_Source")]
        public byte[] AddRecursive_UsingRecursiveAlgorithm_ValuesAreAdded(byte[] firstArray, byte[] secondArray)
        {
            // Arrange

            // Act
            var result = stairCaseService.AddRecursive(firstArray, secondArray);

            // Assert

            return result;
        }

        [Test]
        public void ValidateArray_WhenValidByteArray_ThenSuccess()
        {
            //Arrange
            string[] array = { "15" };

            // Act
            var result = stairCaseService.ValidateArray(array);

            //Assert

            Assert.IsTrue(result.IsSucceed);
            Assert.AreEqual(15, result.Data[0]);
        }

        [Test]
        public void ValidateArray_WhenInValidByteArray_ThenFails()
        {
            //Arrange
            string[] array = { "256" };

            // Act
            var result = stairCaseService.ValidateArray(array);

            //Assert

            Assert.IsFalse(result.IsSucceed);
        }

    }
}
