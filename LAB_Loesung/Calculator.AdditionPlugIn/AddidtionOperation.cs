public class AdditionPlugin : ICalculatorPlugIn
{
    public string Name { get; set; } = "Addition";
    public string OperatorDescription { get; set; } = "+";
    public double Operation(double a, double b)
        => a + b;
}