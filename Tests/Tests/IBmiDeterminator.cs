using Tests.Model;

namespace Tests
{
    public interface IBmiDeterminator
    {
        BmiClassification DeterminateBmi(double bmi);
    }
}