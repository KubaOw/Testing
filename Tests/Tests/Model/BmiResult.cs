using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Model
{
    public class BmiResult
    {
        public double Bmi { get; set; }
        public BmiClassification BmiClassification { get; set; }
        public string Summary { get; set; }
    }
}
