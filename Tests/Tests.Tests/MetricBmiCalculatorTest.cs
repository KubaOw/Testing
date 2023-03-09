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
        [Theory]
        [InlineData(100, 170, 34.6)]
        [InlineData(77, 160, 30.08)]
        [InlineData(90, 190, 24.93)]
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
        [InlineData(0, 190)]
        [InlineData(-6, 150)]
        [InlineData(67, -90)]
        [InlineData(0, 0)]
        [InlineData(-20, -21)]
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
