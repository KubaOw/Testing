using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Model;
using FluentAssertions;
using Moq;

namespace Tests.Tests
{
    public class BmiCalculatorFacadeTests
    {
        private const string OVERWEIGHT_SUMMARY = "You are bit overweight";
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
            //assert
            //assert  
            //Assert.Equal(24.93, result.Bmi);
            //Assert.Equal(BmiClassification.Overweight, result.BmiClassification);
            //Assert.Equal(OVERWEIGHT_SUMMARY, result.Summary);
            result.Bmi.Should().Be(24.93);
            result.BmiClassification.Should().Be(BmiClassification.Overweight);
            result.Summary.Should().Be(OVERWEIGHT_SUMMARY);
            //result.Bmi.Should().Be(24.93);
            //result.BmiClassification.Should().Be(BmiClassification.Overweight);
            result.Summary.Should().Be(expectedResult);

        }
    }
}
