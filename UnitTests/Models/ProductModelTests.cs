using Microsoft.VisualStudio.TestTools.UnitTesting;
using HWUT.Models;
using System;

namespace UnitTests
{
    [TestClass]
    public class ProductModelTests
    {
        //constructor test
        [TestMethod]
        public void ProductModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ProductModel();

            // Assert
            Assert.IsNotNull(result);
        }

        //Default value tests
        [TestMethod]
        public void ProductModel_Get_Date_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ProductModel();

            // Assert
            Assert.AreEqual(DateTime.UtcNow.ToShortDateString(), result.Date.ToShortDateString());
        }

        [TestMethod]
        public void ProductModel_Get_Logistics_Default_Should_Pass()
        {
            // Arrange
            var testValue = "";

            // Act
            var result = new ProductModel();

            // Assert
            Assert.AreEqual(testValue, result.Logistics);
        }

        [TestMethod]
        public void ProductModel_Get_Email_Default_Should_Pass()
        {
            // Arrange
            var testValue = "Unknown";

            // Act
            var result = new ProductModel();

            // Assert
            Assert.AreEqual(testValue, result.Email);
        }

        [TestMethod]
        public void ProductModel_Get_Ratings_Default_Should_Pass()
        {
            // Arrange
            var testValue = 5;

            // Act
            var result = new ProductModel();

            // Assert
            Assert.AreEqual(testValue, result.Ratings[0]);
        }

        [TestMethod]
        public void ProductModel_GetAverageRating_Valid_Should_Return_5()
        {
            // Arrange
            var data = new ProductModel();

            // Act
            var result = data.AverageRating();

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void ProductModel_GetAverageRating_Null_Rating_Should_Return_0()
        {
            // Arrange
            var data = new ProductModel();
            data.Ratings = null;

            // Act
            var result = data.AverageRating();

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ProductModel_GetAverageRating_Empty_Rating_Should_Return_0()
        {
            // Arrange
            var data = new ProductModel();
            data.Ratings = new int[1];

            // Act
            var result = data.AverageRating();

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ProductModel_GetAverageRating_0_Total_Rating_Should_Return_0()
        {
            // Arrange
            var data = new ProductModel();
            data.Ratings[0] = 0;

            // Act
            var result = data.AverageRating();

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ProductModel_GetAverageRating_Rating_Integer_Division_Truncation_Should_Pass()
        {
            // Arrange
            var data = new ProductModel();
            data.Ratings = new int[] { 5, 5, 4 };

            // Act
            var result = data.AverageRating();

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void ProductModel_GetAverageRating_Rating_Integer_Division_Untruncated_Should_Pass()
        {
            // Arrange
            var data = new ProductModel();
            data.Ratings = new int[] { 5, 5 };

            // Act
            var result = data.AverageRating();

            // Assert
            Assert.AreEqual(5, result);
        }
    }
}
