namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);

        }

        [TestMethod]
        public void Sum_n3_and_n4_results_n7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(-5, -4);

            //Assert
            Assert.AreEqual(-9, result);

        }

        [TestMethod]
        [TestCategory("Exceptiontest")]
        public void Sum_intMAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
            //Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MinValue, -1));
        }


        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(1, 2, 3)]
        [DataRow(5000, 2222, 7222)]
        [DataRow(-5, -6, -11)]
        [DataRow(5, -8, -3)]
        public void Sum_with_datarows(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(exp, result);
        }
    }
}