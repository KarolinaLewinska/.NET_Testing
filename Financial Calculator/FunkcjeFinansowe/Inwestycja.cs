using System;

namespace FinancialFunctions
{
    public class Investment
    {
        public double countFutureValue(double initialSum, double interest, int numberOfPeriods)
        {
            if (initialSum <= 0 || numberOfPeriods <=0)
                throw new ArgumentException("Kwota początkowa lub liczba okresów nie mogą być ujemne!"); 

            double countFutureValue =  initialSum * (1 + interest) * numberOfPeriods;
            return countFutureValue;
        }

        public double countInterestRate(double initialSum, double finalSum, int numberOfPeriods)
        {
            double interestRate;

            if (initialSum > finalSum)
                throw new ArgumentException("Kwota początkowa nie może być większa niż sum końcowa");

            if (initialSum == 0)
                throw new DivideByZeroException("Dzielenie przez zero zabronione");

            if (numberOfPeriods == 0)
                throw new ArgumentException("Liczba okresów nie może wynosić 0");

            interestRate = ((finalSum / initialSum) - 1) * numberOfPeriods;
            return interestRate;
        }
    }
}
