using CalculatorApp;

var calculator = new Calculator();
var stringManager = new StringResourceManager(Path.Combine(AppContext.BaseDirectory, "appstrings.json"));

void RunCalculator()
{
    bool continueCalculating = true;

    while (continueCalculating)
    {
        try
        {
            if (!InputValidator.TryGetNumber(stringManager.GetPrompt("enterFirstNumber"), out double num1))
            {
                Console.WriteLine(stringManager.GetMessage("invalidInput"));
                continue;
            }

            if (!InputValidator.TryGetOperator(out Operator operatorEnum))
            {
                Console.WriteLine(stringManager.GetMessage("invalidOperator"));
                continue;
            }

            if (!InputValidator.TryGetNumber(stringManager.GetPrompt("enterSecondNumber"), out double num2))
            {
                Console.WriteLine(stringManager.GetMessage("invalidInput"));
                continue;
            }

            if (calculator.IsValidOperator(operatorEnum))
            {
                double result = calculator.Calculate(num1, operatorEnum, num2);
                string operatorSymbol = InputValidator.OperatorToString(operatorEnum);
                Console.WriteLine($"{stringManager.GetMessage("result")}{num1} {operatorSymbol} {num2} = {result}");
            }
            else
            {
                Console.WriteLine(stringManager.GetMessage("invalidOperator"));
                continue;
            }

            continueCalculating = InputValidator.GetContinueChoice();
            if (continueCalculating)
            {
                Console.WriteLine();
            }
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine($"{stringManager.GetMessage("divideByZeroError")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{stringManager.GetMessage("unexpectedError")}{ex.Message}\n");
        }
    }

    Console.WriteLine(stringManager.GetMessage("goodbye"));
}

RunCalculator();

