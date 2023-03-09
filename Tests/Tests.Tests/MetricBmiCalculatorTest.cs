using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Calculator;

namespace Tests.Tests
{
    public class MetricBmiCalculatorTest
    {
        public static IEnumerable<object[]> GetSampleCorrectData()
        {
            yield return new object[] { 100, 170, 34.6 };
            yield return new object[] { 77, 160, 30.08 };
            yield return new object[] { 90, 190, 24.93 };
        }
        public static IEnumerable<object[]> GetSampleInCorrectData()
        {
            yield return new object[] { 0, 190 };
            yield return new object[] { -6, 150 };
            yield return new object[] { 67, -90 };
            yield return new object[] { 0, 0 };
            yield return new object[] { -20, -21 };
        }
        [Theory]
        [MemberData(nameof(GetSampleCorrectData))]
        public void CalculateBmi_ForGivenWeightAndHeight_ReturnsCorrectBmi(double weight, double height, double bmiResult)
        {
            //arrange 
            MetricBmiCalculator calculator = new MetricBmiCalculator();
            //act
            double result = calculator.CalculateBmi(weight, height);
            //assert
            Assert.Equal(bmiResult, result);
        }

        [Theory]
        [MemberData(nameof(GetSampleInCorrectData))]
        public void CalculateBmi_ForInvalidArguments_ThrowsArgumentException(double weight, double height)
        {
            //arrange 
            MetricBmiCalculator calculator = new MetricBmiCalculator();
            //act
            Action action = () => calculator.CalculateBmi(weight, height);//delegata
            //assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
