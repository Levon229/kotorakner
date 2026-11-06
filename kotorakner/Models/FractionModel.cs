
namespace Kotorakner.Models;

public class FractionModel
{
    public int Numerator1 { get; set; }

    public int Denominator1 { get; set; }

    public int Numerator2 { get; set; }

    public int Denominator2 { get; set; }

    public string Operation { get; set; } = "+";

    public string Result { get; set; } = "";
}
