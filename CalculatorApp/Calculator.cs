using CalculatorApp;

public class Calculator
{
    private readonly Dictionary<Operator, Func<double, double, double>> _operations;

    public Calculator()
    {
        _operations = new Dictionary<Operator, Func<double, double, double>>
        {
            { Operator.Add, (a, b) => a + b },
            { Operator.Subtract, (a, b) => a - b },
            { Operator.Multiply, (a, b) => a * b },
            { Operator.Divide, (a, b) => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by zero") },
            { Operator.Modulus, (a, b) => b != 0 ? a % b : throw new DivideByZeroException("Cannot divide by zero") }
        };
    }

    /// <summary>
    /// Calculates the result of an operation using the Operator enum.
    /// </summary>
    public double Calculate(double num1, Operator op, double num2)
    {
        if (_operations.TryGetValue(op, out var operation))
        {
            return operation(num1, num2);
        }
        throw new InvalidOperationException($"Invalid operator: {op}");
    }

    public bool IsValidOperator(Operator op)
    {
        return _operations.ContainsKey(op);
    }

    /// <summary>
    /// Gets all supported operators.
    /// </summary>
    public Operator[] GetSupportedOperators()
    {
        return _operations.Keys.ToArray();
    }
}
