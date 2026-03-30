public class InputValidator
{
    public static bool TryGetNumber(string prompt, out double number)
    {
        Console.Write(prompt);
        return double.TryParse(Console.ReadLine(), out number);
    }

    public static string GetOperator()
    {
        Console.Write("Enter operator (+, -, *, /, %): ");
        return Console.ReadLine()?.Trim() ?? "";
    }

    public static bool GetContinueChoice()
    {
        Console.Write("\nDo you want to perform another calculation? (yes/no): ");
        string input = Console.ReadLine()?.Trim().ToLower() ?? "no";
        return input == "yes" || input == "y";
    }
}
