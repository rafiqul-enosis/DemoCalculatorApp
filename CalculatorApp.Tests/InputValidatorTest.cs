namespace CalculatorApp.Tests;

public class InputValidatorTest
{
    [Fact]
    public void GetOperator_ReturnsOperatorAsIs_WithoutTrimming()
    {
        string operatorWithSpaces = " + ";
        var calculator = new Calculator();
        
        Assert.False(calculator.IsValidOperator(operatorWithSpaces));
        Assert.True(calculator.IsValidOperator(operatorWithSpaces.Trim()));
    }

    [Fact]
    public void Calculate_WithOperatorContainingWhitespace_ShouldTrimAndWork()
    {
        var calculator = new Calculator();
        
        double result = calculator.Calculate(10, " + ", 5);
        Assert.Equal(15, result);
    }

    [Fact]
    public void Calculate_WithSpacedOperator_ShouldTrimAndExecute()
    {
        var calculator = new Calculator();
        
        double result = calculator.Calculate(20, " / ", 4);
        Assert.Equal(5, result);
    }
}

