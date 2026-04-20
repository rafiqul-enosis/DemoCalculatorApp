namespace CalculatorApp.Tests;

public class InputValidatorTest
{
    [Fact]
    public void StringToOperator_ValidOperators_ConvertsSuccessfully()
    {
        Assert.True(InputValidator.StringToOperator("+", out Operator op));
        Assert.Equal(Operator.Add, op);
    }

    [Fact]
    public void StringToOperator_InvalidOperators_ReturnsFalse()
    {
        Assert.False(InputValidator.StringToOperator("^", out _));
        Assert.False(InputValidator.StringToOperator("&", out _));
    }

    [Fact]
    public void Calculate_WithOperatorEnum_ReturnsCorrectResult()
    {
        var calculator = new Calculator();
        
        double result = calculator.Calculate(10, Operator.Add, 5);
        Assert.Equal(15, result);
    }

    [Fact]
    public void OperatorToString_ConvertsEnumToSymbol()
    {
        Assert.Equal("+", InputValidator.OperatorToString(Operator.Add));
        Assert.Equal("-", InputValidator.OperatorToString(Operator.Subtract));
        Assert.Equal("*", InputValidator.OperatorToString(Operator.Multiply));
        Assert.Equal("/", InputValidator.OperatorToString(Operator.Divide));
        Assert.Equal("%", InputValidator.OperatorToString(Operator.Modulus));
    }
}
