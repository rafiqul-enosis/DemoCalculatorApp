using CalculatorApp;

public class InputValidator
{
    private static readonly StringResourceManager _stringManager = new StringResourceManager(
        Path.Combine(AppContext.BaseDirectory, "appstrings.json"));

    public static bool TryGetNumber(string prompt, out double number)
    {
        Console.Write(prompt);
        return double.TryParse(Console.ReadLine(), out number);
    }

    /// <summary>
    /// Gets operator input from user and converts it to an Operator enum.
    /// </summary>
    public static bool TryGetOperator(out Operator op)
    {
        Console.Write(_stringManager.GetPrompt("enterOperator"));
        string input = Console.ReadLine()?.Trim() ?? "";
        
        return StringToOperator(input, out op);
    }

    /// <summary>
    /// Converts a string operator symbol to the Operator enum.
    /// </summary>
    public static bool StringToOperator(string symbol, out Operator op)
    {
        op = default;
        
        return symbol switch
        {
            "+" => (op = Operator.Add) == Operator.Add,
            "-" => (op = Operator.Subtract) == Operator.Subtract,
            "*" => (op = Operator.Multiply) == Operator.Multiply,
            "/" => (op = Operator.Divide) == Operator.Divide,
            "%" => (op = Operator.Modulus) == Operator.Modulus,
            _ => false
        };
    }

    /// <summary>
    /// Converts an Operator enum to its string representation.
    /// </summary>
    public static string OperatorToString(Operator op)
    {
        return op switch
        {
            Operator.Add => "+",
            Operator.Subtract => "-",
            Operator.Multiply => "*",
            Operator.Divide => "/",
            Operator.Modulus => "%",
            _ => ""
        };
    }

    public static bool GetContinueChoice()
    {
        Console.Write(_stringManager.GetPrompt("continueCalculation"));
        string input = Console.ReadLine()?.Trim().ToLower() ?? "no";
        return input == "yes" || input == "y";
    }
}
