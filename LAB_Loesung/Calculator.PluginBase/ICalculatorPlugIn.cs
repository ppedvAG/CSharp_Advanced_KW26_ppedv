

public interface ICalculatorPlugIn
{
    string Name { get; set; }
    string OperatorDescription { get; set; }
    double Operation (double a, double b);    
}
