using Tests.Model;

namespace Tests.Tests
{
    public class BmiDeterminatorTests
    {
        [Theory]
        [InlineData(10.0, BmiClassification.Underweight)]
        [InlineData(18.0, BmiClassification.Underweight)]
        [InlineData(8.0, BmiClassification.Underweight)]
        [InlineData(19.0, BmiClassification.Normal)]
        [InlineData(21.0, BmiClassification.Normal)]
        [InlineData(24.8, BmiClassification.Normal)]
        [InlineData(25.8, BmiClassification.Overweight)]
        [InlineData(28.8, BmiClassification.Overweight)]
        [InlineData(30.8, BmiClassification.Obesity)]
        [InlineData(35.9, BmiClassification.ExtremeObesity)]
        public void DeterminateBmi_ForGivenBmi_ReturnsCorrectClassification(double bmi, BmiClassification classification)
        {
            //arrange
            BmiDeterminator bmiDeterminator = new BmiDeterminator();
            //act
            BmiClassification result = bmiDeterminator.DeterminateBmi(bmi);
            //assert
            Assert.Equal(classification, result);
        }
    }
}