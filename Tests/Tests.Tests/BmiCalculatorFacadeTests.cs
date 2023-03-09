using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Model;
using FluentAssertions;
using Moq;
using Xunit.Abstractions;

namespace Tests.Tests
{
    public class BmiCalculatorFacadeTests
    {
        public BmiCalculatorFacadeTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        private const string OVERWEIGHT_SUMMARY = "You are bit overweight";
        private readonly ITestOutputHelper _outputHelper;
        [Theory]
        [InlineData(BmiClassification.Overweight, OVERWEIGHT_SUMMARY)]
        public void GetResult_ForValidInputs_ReturnsCorrectSummary(BmiClassification bmiClassification, string expectedResult)
        {
            //arrange
            var bmiDeterminatorMock = new Mock<IBmiDeterminator>();
            bmiDeterminatorMock.Setup(m => m.DeterminateBmi(It.IsAny<double>()))
                .Returns(bmiClassification);
            var bmiCalculatorFacade = new BmiCalculatorFacade(UnitSystem.Metric, bmiDeterminatorMock.Object);
            //act
            BmiResult result = bmiCalculatorFacade.GetResult(1, 1);
            _outputHelper.WriteLine($"For classification: {bmiClassification} the result is: {result.Summary}");
            //assert
            //assert  
            //Assert.Equal(24.93, result.Bmi);
            //Assert.Equal(BmiClassification.Overweight, result.BmiClassification);
            //Assert.Equal(OVERWEIGHT_SUMMARY, result.Summary);

            //result.Bmi.Should().Be(24.93);
            //result.BmiClassification.Should().Be(BmiClassification.Overweight);
            //result.Summary.Should().Be(expectedResult);

            result.Summary.Should().Be(OVERWEIGHT_SUMMARY);

        }
    }
}
