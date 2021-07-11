using NUnit.Framework;
using System;

namespace FinancialFunctions.Tests
{
    [TestFixture]
    public class InwestycjaTests
    {
        Investment inw;

        [OneTimeSetUp]
        public void setUp()
        {
            inw = new Investment();
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            inw = null;
        }

        [TestCase(200, 250, 0.25, 3)] 
        [TestCase(200, 250.22, 0.2511, 3)]
        [TestCase(200.22, 250, 0.248627, 3)]
        [TestCase(200.22, 250.22, 0.249725, 3)]
        public void countInteresstRate_TestCases(double initialSum, double finalSum, double referenceValue, int numberOfPeriods)
        {
            double sum = inw.countInterestRate(initialSum, finalSum, numberOfPeriods);
            Assert.AreEqual(sum, referenceValue * numberOfPeriods, 5);
        }
       
        [Test] 
        [Ignore("Ignore test")] 
        public void countFutureValue_IntegerParameters()
        {
            double sum = inw.countFutureValue(1000, 1, 3);
            Assert.AreEqual(sum, 2000.00); 
        }

        [Test] 
        public void countFutureValue_DoubleParameters()
        {
            double sum = inw.countFutureValue(1000.00, 0.04, 3); 
            Assert.AreEqual(sum, 3120.00); 
        }

        [Test]
        public void countFutureValue_NegativeValue_Exception() 
        {
            var ex = Assert.Throws<ArgumentException>(
                () => inw.countFutureValue(-1000, 0.04, 3));

            Assert.That(ex.Message == "Kwota nie może być ujemna");
        }

        [Test]
        public void countInterestRate_InitialSumGreaterThanFinalSum_Exception()
        {
            Assert.Throws(Is.TypeOf<ArgumentException>() 
                .And.Message.EqualTo("Kwota początkowa nie może być większa niż sum końcowa"),
                
                delegate
                {
                    inw.countInterestRate(1000.00, 100.00, 3);  
                });
        }

        [Test]
        public void countFutureValue_InitialSumIsDoubleInterestIsInt()
        {
            double sum = inw.countFutureValue(1000.00, 1, 3); 
            Assert.AreEqual(sum, 6000.00);
        }

        [Test]
        public void countFutureValue_InitialSumIsIntInterestIsDouble()
        {
            double sum = inw.countFutureValue(1000, 0.04, 3); 
            Assert.AreEqual(sum, 3120.00);
        }

        [Test]
        public void countInterestRate_DivideByZero_Exception()
        {
            Assert.Throws(Is.TypeOf<DivideByZeroException>() 
                .And.Message.EqualTo("Dzielenie przez zero zabronione"),

                delegate
                {
                    inw.countInterestRate(0.00, 1000.00, 3);   
                });
        }

        [Test]
        public void numberOfPeriods_NegativeValue_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => inw.countFutureValue(1000, 0.04, -3));

            Assert.That(ex.Message == "Liczba okresów nie może być ujemna");
        }

        [Test]
        public void countFutureValue_NumberOfPeriodsEquallsZero_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => inw.countFutureValue(1000, 0.04, 0));

            Assert.That(ex.Message == "Liczba okresów nie może wynosić 0");
        }

        [Test]
        public void countFutureValue_InterestEquallsZero_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(
               () => inw.countFutureValue(1000, 0, 4));

            Assert.That(ex.Message == "Oprocentowanie nie może wynosić 0");
        } 
    }
}
