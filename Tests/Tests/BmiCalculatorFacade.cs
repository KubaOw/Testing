using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Calculator;
using Tests.Model;

namespace Tests
{
    public class BmiCalculatorFacade
    {
        private readonly UnitSystem _unitSystem;
        private readonly IBmiCalculator _bmiCalculator;
        private readonly IBmiDeterminator _bmiDeterminator;

        private IBmiCalculator GetBmiCalculator(UnitSystem unitSystem)
            =>
                unitSystem switch
                {
                    UnitSystem.Imperial => new ImperialBmiCalculator(),
                    UnitSystem.Metric => new MetricBmiCalculator(),
                    _ => throw new NotImplementedException()
                };
        private string GetSummary(BmiClassification classification)
            => classification switch
            {
                BmiClassification.Underweight => "You are underweight",
                BmiClassification.Normal => "Your weight is normal",
                BmiClassification.Overweight => "You are bit overweight",
                BmiClassification.Obesity => "You should care",
                BmiClassification.ExtremeObesity => "You are extreme obese",
                _ => throw new NotImplementedException(),
            };
        public BmiCalculatorFacade(UnitSystem unitSystem, IBmiDeterminator bmiDeterminator)
        {
            _unitSystem = unitSystem;
            _bmiDeterminator = bmiDeterminator;
            _bmiCalculator = GetBmiCalculator(unitSystem);
        }

        public BmiResult GetResult(double weight, double height)
        {
            var bmi = _bmiCalculator.CalculateBmi(weight, height);
            var classification = _bmiDeterminator.DeterminateBmi(bmi);

            return new BmiResult()
            {
                Bmi = bmi,
                BmiClassification = classification,
                Summary = GetSummary(classification)
            };
        }
    }
}
