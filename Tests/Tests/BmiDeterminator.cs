using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Model;

namespace Tests
{
    public class BmiDeterminator
    {
        public BmiClassification DeterminateBmi(double bmi) => bmi switch
        {
            < 18.5 => BmiClassification.Underweight,
            < 24.9 => BmiClassification.Normal,
            < 29.9 => BmiClassification.Overweight,
            <= 34.9 => BmiClassification.Obesity,
            _ => BmiClassification.ExtremeObesity
        };
    }
}
