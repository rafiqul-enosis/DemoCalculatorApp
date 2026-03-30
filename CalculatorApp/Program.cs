// Copyright (c) 2023 Sage software, Inc. - All rights reserves.
var calculator = new Calculator();

void RunCalculator()
{
    bool continueCalculating = true;

    while (continueCalculating)
    {
        try
        {
            if (!InputValidator.TryGetNumber("Enter first number: ", out double num1))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.\n");
                continue;
            }

            string operatorInput = InputValidator.GetOperator();

            if (!InputValidator.TryGetNumber("Enter second number: ", out double num2))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.\n");
                continue;
            }

            if (calculator.IsValidOperator(operatorInput))
            {
                double result = calculator.Calculate(num1, operatorInput, num2);
                Console.WriteLine($"Result: {num1} {operatorInput} {num2} = {result}");
            }
            else
            {
                Console.WriteLine("Invalid operator. Please use +, -, *, /, or %\n");
                continue;
            }

            continueCalculating = InputValidator.GetContinueChoice();
            if (continueCalculating)
            {
                Console.WriteLine();
            }
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error: {ex.Message}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}\n");
        }
    }

    Console.WriteLine("Thank you for using the calculator. Goodbye!");
}

RunCalculator();
