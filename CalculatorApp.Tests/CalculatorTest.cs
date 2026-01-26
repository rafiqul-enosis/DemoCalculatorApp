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
        double result = _calculator.Calculate(10, "+", 5);
        Assert.Equal(15, result);
    }

    [Fact]
    public void Addition_WithNegativeNumbers_ReturnsCorrectSum()
    {
        double result = _calculator.Calculate(-10, "+", 5);
        Assert.Equal(-5, result);
    }

    [Fact]
    public void Subtraction_LargerMinusSmaller_ReturnsCorrectDifference()
    {
        double result = _calculator.Calculate(10, "-", 3);
        Assert.Equal(7, result);
    }

    [Fact]
    public void Subtraction_NegativeResult()
    {
        double result = _calculator.Calculate(3, "-", 10);
        Assert.Equal(-7, result);
    }

    [Fact]
    public void Multiplication_TwoNumbers_ReturnsCorrectProduct()
    {
        double result = _calculator.Calculate(6, "*", 7);
        Assert.Equal(42, result);
    }

    [Fact]
    public void Multiplication_WithZero_ReturnsZero()
    {
        double result = _calculator.Calculate(10, "*", 0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Division_ValidNumbers_ReturnsCorrectQuotient()
    {
        double result = _calculator.Calculate(20, "/", 4);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Division_ResultingInDecimal()
    {
        double result = _calculator.Calculate(10, "/", 3);
        Assert.Equal(10.0 / 3.0, result);
    }

    [Fact]
    public void Division_DivideByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Calculate(10, "/", 0));
    }

    [Fact]
    public void IsValidOperator_WithValidSymbols_ReturnsTrue()
    {
        Assert.True(_calculator.IsValidOperator("+"));
        Assert.True(_calculator.IsValidOperator("-"));
        Assert.True(_calculator.IsValidOperator("*"));
        Assert.True(_calculator.IsValidOperator("/"));
    }

    [Fact]
    public void IsValidOperator_WithInvalidSymbol_ReturnsFalse()
    {
        Assert.False(_calculator.IsValidOperator("^"));
        Assert.False(_calculator.IsValidOperator("&"));
        Assert.False(_calculator.IsValidOperator(""));
    }

    [Fact]
    public void Modulo_TwoNumbers_ReturnsCorrectRemainder()
    {
        double result = _calculator.Calculate(10, "%", 3);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Modulo_EvenDivisor_ReturnsZero()
    {
        double result = _calculator.Calculate(20, "%", 5);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Modulo_DivideByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Calculate(10, "%", 0));
    }

    [Fact]
    public void IsValidOperator_WithModulo_ReturnsTrue()
    {
        Assert.True(_calculator.IsValidOperator("%"));
    }
}