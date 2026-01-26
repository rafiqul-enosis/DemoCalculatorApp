namespace CalculatorApp.Tests;

public class CalculatorTest
{
    private readonly Calculator _calculator;

    public CalculatorTest()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Addition_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        double result = _calculator.Calculate(10, Operator.Add, 5);
        Assert.Equal(15, result);
    }

    [Fact]
    public void Addition_WithNegativeNumbers_ReturnsCorrectSum()
    {
        double result = _calculator.Calculate(-10, Operator.Add, 5);
        Assert.Equal(-5, result);
    }

    [Fact]
    public void Subtraction_LargerMinusSmaller_ReturnsCorrectDifference()
    {
        double result = _calculator.Calculate(10, Operator.Subtract, 3);
        Assert.Equal(7, result);
    }

    [Fact]
    public void Subtraction_NegativeResult()
    {
        double result = _calculator.Calculate(3, Operator.Subtract, 10);
        Assert.Equal(-7, result);
    }

    [Fact]
    public void Multiplication_TwoNumbers_ReturnsCorrectProduct()
    {
        double result = _calculator.Calculate(6, Operator.Multiply, 7);
        Assert.Equal(42, result);
    }

    [Fact]
    public void Multiplication_WithZero_ReturnsZero()
    {
        double result = _calculator.Calculate(10, Operator.Multiply, 0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Division_ValidNumbers_ReturnsCorrectQuotient()
    {
        double result = _calculator.Calculate(20, Operator.Divide, 4);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Division_ResultingInDecimal()
    {
        double result = _calculator.Calculate(10, Operator.Divide, 3);
        Assert.Equal(10.0 / 3.0, result);
    }

    [Fact]
    public void Division_DivideByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Calculate(10, Operator.Divide, 0));
    }

    [Fact]
    public void IsValidOperator_WithValidEnumValues_ReturnsTrue()
    {
        Assert.True(_calculator.IsValidOperator(Operator.Add));
        Assert.True(_calculator.IsValidOperator(Operator.Subtract));
        Assert.True(_calculator.IsValidOperator(Operator.Multiply));
        Assert.True(_calculator.IsValidOperator(Operator.Divide));
    }

    [Fact]
    public void Modulo_TwoNumbers_ReturnsCorrectRemainder()
    {
        double result = _calculator.Calculate(10, Operator.Modulus, 3);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Modulo_EvenDivisor_ReturnsZero()
    {
        double result = _calculator.Calculate(10, Operator.Modulus, 2);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Modulo_DivideByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Calculate(10, Operator.Modulus, 0));
    }

    [Fact]
    public void StringToOperator_ValidSymbols_ConvertsCorrectly()
    {
        Assert.True(InputValidator.StringToOperator("+", out var op1) && op1 == Operator.Add);
        Assert.True(InputValidator.StringToOperator("-", out var op2) && op2 == Operator.Subtract);
        Assert.True(InputValidator.StringToOperator("*", out var op3) && op3 == Operator.Multiply);
        Assert.True(InputValidator.StringToOperator("/", out var op4) && op4 == Operator.Divide);
        Assert.True(InputValidator.StringToOperator("%", out var op5) && op5 == Operator.Modulus);
    }

    [Fact]
    public void StringToOperator_InvalidSymbols_ReturnsFalse()
    {
        Assert.False(InputValidator.StringToOperator("^", out _));
        Assert.False(InputValidator.StringToOperator("&", out _));
        Assert.False(InputValidator.StringToOperator("", out _));
    }

    [Fact]
    public void OperatorToString_ConvertsEnumToString()
    {
        Assert.Equal("+", InputValidator.OperatorToString(Operator.Add));
        Assert.Equal("-", InputValidator.OperatorToString(Operator.Subtract));
        Assert.Equal("*", InputValidator.OperatorToString(Operator.Multiply));
        Assert.Equal("/", InputValidator.OperatorToString(Operator.Divide));
        Assert.Equal("%", InputValidator.OperatorToString(Operator.Modulus));
    }
}
