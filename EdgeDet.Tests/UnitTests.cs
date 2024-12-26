using System;
using EdgeDet.Controllers;
using EdgeDet.Models;
using EdgeDet.Views;
using NUnit.Framework;

namespace EdgeDet.Tests
{
    [TestFixture]
    public class EdgeDetectionTests
    {
        [Test]
        public void OperatorSelection_Sobel_ReturnsSobelOperator()
        {
            // Arrange
            string operatorType = "sobel";

            // Act
            EdgeDetectionOperator operatorInstance = SelectOperator(operatorType);

            // Assert
            Assert.That(operatorInstance, Is.InstanceOf<SobelOperator>());
        }

        [Test]
        public void OperatorSelection_Prewitt_ReturnsPrewittOperator()
        {
            // Arrange
            string operatorType = "prewitt";

            // Act
            EdgeDetectionOperator operatorInstance = SelectOperator(operatorType);

            // Assert
            Assert.That(operatorInstance, Is.InstanceOf<PrewittOperator>());
        }

        [Test]
        public void EdgeDetection_SobelOperator_ReturnsExpectedOutput()
        {
            // Arrange
            var sobelOperator = new SobelOperator();
            int[,] sampleImage = {
                { 10, 10, 10 },
                { 10, 20, 10 },
                { 10, 10, 10 }
            };

            // Act
            int[,] result = sobelOperator.Apply(sampleImage);

            // Assert
            int[,] expected = {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 }
            };
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result.GetLength(0), Is.EqualTo(sampleImage.GetLength(0)));
            Assert.That(result.GetLength(1), Is.EqualTo(sampleImage.GetLength(1)));
        }

        [Test]
        public void EdgeDetection_PrewittOperator_ReturnsExpectedOutput()
        {
            // Arrange
            var prewittOperator = new PrewittOperator();
            int[,] sampleImage = {
                { 10, 10, 10 },
                { 10, 20, 10 },
                { 10, 10, 10 }
            };

            // Act
            int[,] result = prewittOperator.Apply(sampleImage);

            // Assert
            int[,] expected = {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 }
            };
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result.GetLength(0), Is.EqualTo(sampleImage.GetLength(0)));
            Assert.That(result.GetLength(1), Is.EqualTo(sampleImage.GetLength(1)));
        }

        // Helper method for operator selection
        private EdgeDetectionOperator SelectOperator(string operatorType)
        {
            return operatorType.ToLower() switch
            {
                "sobel" => new SobelOperator(),
                "prewitt" => new PrewittOperator(),
                _ => throw new ArgumentException("Invalid operator type.")
            };
        }
    }

    // Mock ConsoleView for testing
    internal class MockConsoleView : ConsoleView
    {
        private readonly string _inputPath;
        private readonly string _operatorType;
        private readonly string _outputPath;

        public MockConsoleView(string inputPath, string operatorType, string outputPath)
        {
            _inputPath = inputPath;
            _operatorType = operatorType;
            _outputPath = outputPath;
        }

        public override string GetImagePath() => _inputPath;
        public override string GetOperatorType() => _operatorType;
        public override string GetOutputPath() => _outputPath;
    }
}
