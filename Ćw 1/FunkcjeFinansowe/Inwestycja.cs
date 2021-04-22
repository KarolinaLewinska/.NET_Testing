using System;

namespace FunkcjeFinansowe
{
    public class Inwestycja
    {
        public double wartoscPrzyszla(double kwotaPoczatkowa, double oprocentowanie, int liczbaOkresow)
        {
            if (kwotaPoczatkowa <= 0 || liczbaOkresow <=0)
                throw new ArgumentException("Kwota początkowa lub liczba okresów nie mogą być ujemne!"); 

            double wartoscPrzyszla =  kwotaPoczatkowa * (1 + oprocentowanie) * liczbaOkresow;
            return wartoscPrzyszla;
        }

        public double wyliczStope(double kwotaPoczatkowa, double kwotaKoncowa, int liczbaOkresow)
        {
            double stopa;

            if (kwotaPoczatkowa > kwotaKoncowa)
                throw new ArgumentException("Kwota początkowa nie może być większa niż kwota końcowa");

            if (kwotaPoczatkowa == 0)
                throw new DivideByZeroException("Dzielenie przez zero zabronione");

            if (liczbaOkresow == 0)
                throw new ArgumentException("Liczba okresów nie może wynosić 0");

            stopa = ((kwotaKoncowa / kwotaPoczatkowa) - 1) * liczbaOkresow;
            return stopa;
        }
    }
}
