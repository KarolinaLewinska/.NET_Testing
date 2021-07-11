using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersConversion;
using System;

namespace NumberaConversion.Tests
{
    [TestClass]
    public class NumberTest
    {
        public TestContext TestContext { get; set; }
        Number number;

        [TestInitialize]
        public void setUp()
        {
            number = new Number();
        }

        [TestMethod]
        public void convertToArabic_I()
        {
            Assert.AreEqual(1, number.convertRomeNumberToArabic("I"));
        }

        [TestMethod]
        public void convertToArabic_III()
        {
            Assert.AreEqual(3, number.convertRomeNumberToArabic("III"));
        }

        [TestMethod]
        public void convertToArabic_IV()
        {
            Assert.AreEqual(4, number.convertRomeNumberToArabic("IV"));
        }

        [TestMethod]
        public void convertToArabic_V()
        {
            Assert.AreEqual(5, number.convertRomeNumberToArabic("V"));
        }

        [TestMethod]
        public void convertToArabic_VII()
        {
            Assert.AreEqual(7, number.convertRomeNumberToArabic("VII"));
        }

        [TestMethod]
        public void convertToArabic_IX()
        {
            Assert.AreEqual(9, number.convertRomeNumberToArabic("IX"));
        }

        [TestMethod]
        public void convertToArabic_X()
        {
            Assert.AreEqual(10, number.convertRomeNumberToArabic("X"));
        }

        [TestMethod]
        public void convertToArabic_XXIX()
        {
            Assert.AreEqual(29, number.convertRomeNumberToArabic("XXIX"));
        }

        [TestMethod]
        public void convertToArabic_L()
        {
            Assert.AreEqual(50, number.convertRomeNumberToArabic("L"));
        }

        [TestMethod]
        public void convertToArabic_C()
        {
            Assert.AreEqual(100, number.convertRomeNumberToArabic("C"));
        }

        [TestMethod]
        public void convertToArabic_CD()
        {
            Assert.AreEqual(400, number.convertRomeNumberToArabic("CD"));
        }

        [TestMethod]
        public void convertToArabic_D()
        {
            Assert.AreEqual(500, number.convertRomeNumberToArabic("D"));
        }

        [TestMethod]
        public void convertToArabic_CM()
        {
            Assert.AreEqual(900, number.convertRomeNumberToArabic("CM"));
        }

        [TestMethod]
        public void convertToArabic_M()
        {
            Assert.AreEqual(1000, number.convertRomeNumberToArabic("M"));
        }

        [TestMethod]
        public void convertToArabic_MMMMMMMMMCMXCVIII()
        {
            Assert.AreEqual(9998, number.convertRomeNumberToArabic("MMMMMMMMMCMXCVIII"));
        }

        [TestMethod]
        public void convertToArabic_MMMMMMMMMCMXCIX()
        {
            Assert.AreEqual(9999, number.convertRomeNumberToArabic("MMMMMMMMMCMXCIX"));
        }

        [TestMethod]
        public void convertToArabic_MMMMMMMMMCMXCIX_smallLetters()
        {
            Assert.AreEqual(9999, number.convertRomeNumberToArabic("mmmmmmmmmcmxcix"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void inputStringIsEmpty_ThrowException()
        {
            try
            {
                number.convertRomeNumberToArabic("");
            }
            catch (FormatException exc)
            {
                Assert.AreEqual("Nie podano liczby!", exc.Message);
                throw exc;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void inputStringHasInvalidLetters_ThrowException()
        {
            try
            {
                number.convertRomeNumberToArabic("32feqwS");
            }
            catch (ArgumentException exc)
            {
                Assert.AreEqual("Wpisano nieprawidłowe znaki!", exc.Message);
                throw exc;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void inputStringHasInvalidNumbers_ThrowException()
        {
            try
            {
                number.convertRomeNumberToArabic("0493123211");
            }
            catch (ArgumentException exc)
            {
                Assert.AreEqual("Wpisano nieprawidłowe znaki!", exc.Message);
                throw exc;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void inputStringInvalidLettersWithValidLetters_ThrowException()
        {
            try
            {
                number.convertRomeNumberToArabic("LCsd");
            }
            catch (ArgumentException exc)
            {
                Assert.AreEqual("Wpisano nieprawidłowe znaki!", exc.Message);
                throw exc;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void inputStringInvalidLettersWithValidLetters2_ThrowException()
        {
            try
            {
                number.convertRomeNumberToArabic("XIfd2i");
            }
            catch (ArgumentException exc)
            {
                Assert.AreEqual("Wpisano nieprawidłowe znaki!", exc.Message);
                throw exc;
            }
        }

        [TestCleanup]   
        public void tearDown()
        {
            number = null;
        }
    }
}

