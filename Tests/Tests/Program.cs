using Tests.Model;
using Tests;

Console.WriteLine("Please give me your weight");
int weight = int.Parse(Console.ReadLine());
Console.WriteLine("Please give me your height");
int height = int.Parse(Console.ReadLine());
Console.WriteLine("Please enter units: Metric or Imperial");
var choosedType = Console.ReadLine();
UnitSystem unitType = (UnitSystem)Enum.Parse(typeof(UnitSystem), choosedType);
BmiCalculatorFacade calculator = new(unitType);
var bmiResult = calculator.GetResult(weight, height);
Console.WriteLine(bmiResult.Bmi + " " + bmiResult.BmiClassification + " " + bmiResult.Summary);
