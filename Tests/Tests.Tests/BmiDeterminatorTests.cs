using Tests.Model;

namespace Tests.Tests
{
    public class BmiDeterminatorTests
    {
        [Fact]
        public void DeterminateBmi_ForBmiBelow18_5_ReturnsUnderweightClassification()
        {
            //arrange
            BmiDeterminator bmiDeterminator = new BmiDeterminator();
            double bmi = 10;
            //act
            BmiClassification result = bmiDeterminator.DeterminateBmi(bmi);
            //assert
            Assert.Equal(BmiClassification.Underweight, result);
        }
    }
}