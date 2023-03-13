namespace Calculator.Tests_Nunit
{
    [TestFixture] //optional
    public class CalcTests_Nunit
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);

        }

        [Test]
        [Category("Exceptiontest")]
        public void Sum_intMAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(1, 2, 3)]
        [TestCase(5000, 2222, 7222)]
        [TestCase(-5, -6, -11)]
        [TestCase(5, -8, -3)]
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