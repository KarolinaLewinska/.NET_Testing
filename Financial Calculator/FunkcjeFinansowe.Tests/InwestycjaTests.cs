using NUnit.Framework;
using System;

namespace FunkcjeFinansowe.Tests
{
    [TestFixture]
    public class InwestycjaTests
    {
        Inwestycja inw;

        [OneTimeSetUp]
        public void setUp()
        {
            inw = new Inwestycja();
        }

        [TestCase(200, 250, 0.25, 3)] 
        [TestCase(200, 250.22, 0.2511, 3)]
        [TestCase(200.22, 250, 0.248627, 3)]
        [TestCase(200.22, 250.22, 0.249725, 3)]
        public void wyliczStope_RozneWartosci_Calculated(double kwotaPoczatkowa, double kwotaKoncowa, double wartoscOdniesienia, int liczbaOkresow)
        {
            double kwota = inw.wyliczStope(kwotaPoczatkowa, kwotaKoncowa, liczbaOkresow);
            Assert.AreEqual(kwota, wartoscOdniesienia * liczbaOkresow, 5);
        }
       
        [Test] 
        [Ignore("A tego testu nie odpalamy, bo nudny")] 
        public void wartoscPrzyszla_ObaParametryInt_Calculated()
        {
            double kwota = inw.wartoscPrzyszla(1000, 1,3);
            Assert.AreEqual(kwota, 2000.00); 
        }

        [Test] 
        public void wartoscPrzyszla_ObaParametryDouble_Calculated()
        {
            double kwota = inw.wartoscPrzyszla(1000.00, 0.04, 3); 
            Assert.AreEqual(kwota, 3120.00); 
        }

        [Test]
        public void wartoscPrzyszla_KwotaUjemna_Exception() 
        {
            var ex = Assert.Throws<ArgumentException>(
                () => inw.wartoscPrzyszla(-1000, 0.04, 3));

            Assert.That(ex.Message == "Kwota nie może być ujemna");
        }

        [Test]
        public void wyliczStope_WartoscPoczatkowaWiekszaNiZKoncowa_Exception()
        {
            Assert.Throws(Is.TypeOf<ArgumentException>() 
                .And.Message.EqualTo("Kwota początkowa nie może być większa niż kwota końcowa"),
                
                delegate
                {
                    inw.wyliczStope(1000.00, 100.00, 3);  
                });
        }

        [Test]
        public void wartoscPrzyszla_KpDoubleOprocInt_Calculated()
        {
            double kwota = inw.wartoscPrzyszla(1000.00, 1, 3); 
            Assert.AreEqual(kwota, 6000.00);
        }

        [Test]
        public void wartoscPrzyszla_KpIntOprocDouble_Calculated()
        {
            double kwota = inw.wartoscPrzyszla(1000, 0.04, 3); 
            Assert.AreEqual(kwota, 3120.00);
        }

        [Test]
        public void wyliczStope_DzieleniePrzezZero_Exception()
        {
            Assert.Throws(Is.TypeOf<DivideByZeroException>() 
                .And.Message.EqualTo("Dzielenie przez zero zabronione"),

                delegate
                {
                    inw.wyliczStope(0.00, 1000.00, 3);   
                });
        }

        [Test]
        public void liczbaOkresow_wartoscUjemna_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => inw.wartoscPrzyszla(1000, 0.04, -3));

            Assert.That(ex.Message == "Liczba okresów nie może być ujemna");
        }

        [Test]
        public void wartoscPrzyszla_LiczbaOkresowWynosiZero_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => inw.wartoscPrzyszla(1000, 0.04, 0));

            Assert.That(ex.Message == "Liczba okresów nie może wynosić 0");
        }

        [Test]
        public void wartoscPrzyszla_oprocentowanieRowneZero_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(
               () => inw.wartoscPrzyszla(1000, 0, 4));

            Assert.That(ex.Message == "Oprocentowanie nie może wynosić 0");
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            inw = null;
        }
    }
}
