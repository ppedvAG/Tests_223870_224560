namespace Calculator.Tests_xUnit
{
    public class CalcTests_xUnit
    {
        [Fact]
        public void Sum_n3_and_n4_results_n7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(-5, -4);

            //Assert
            Assert.Equal(-9, result);
        }

        [Fact]
        [Trait("","Exceptiontest")]
        [Trait("Category","Unittest")]
        public void Sum_intMAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }


        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 3)]
        [InlineData(5000, 2222, 7222)]
        [InlineData(-5, -6, -11)]
        [InlineData(5, -8, -3)]
        public void Sum_with_datarows(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.Equal(exp, result);
        }

    }
}