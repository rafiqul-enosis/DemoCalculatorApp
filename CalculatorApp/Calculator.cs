// Copyright (c) 2023 Sage software, Inc. - All rights reserves.
public class Calculator
{
    //Another
    private readonly Dictionary<string, Func<double, double, double>> _operations;

    public Calculator()
    {
        _operations = new Dictionary<string, Func<double, double, double>>
        {
            { "+", (a, b) => a + b },
            { "-", (a, b) => a - b },
            { "*", (a, b) => a * b },
            { "/", (a, b) => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by zero") },
            { "%", (a, b) => b != 0 ? a % b : throw new DivideByZeroException("Cannot divide by zero") }
        };
    }

    public double Calculate(double num1, string operatorSymbol, double num2)
    {
        string trimmedOperator = operatorSymbol?.Trim() ?? "";
        if (_operations.TryGetValue(trimmedOperator, out var operation))
        {
            return operation(num1, num2);
        }
        throw new InvalidOperationException($"Invalid operator: {operatorSymbol}");
    }

    public bool IsValidOperator(string operatorSymbol)
    {
        return _operations.ContainsKey(operatorSymbol);
    }

    public string[] GetSupportedOperators()
    {
        return _operations.Keys.ToArray();
    }
}
