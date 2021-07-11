using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NumbersConversion
{
    public class Number
    {
        public int convertRomeNumberToArabic(string romeNumber)
        {
            Dictionary<char, int> numberValuePairs = null;
            int arabicNumber = 0;
            int number = 0;

            if (numberValuePairs == null)
            {
                numberValuePairs = new Dictionary<char, int>();
                numberValuePairs.Add('I', 1);
                numberValuePairs.Add('V', 5);
                numberValuePairs.Add('X', 10);
                numberValuePairs.Add('L', 50);
                numberValuePairs.Add('C', 100);
                numberValuePairs.Add('D', 500);
                numberValuePairs.Add('M', 1000);
            }

            if (romeNumber == "") 
                throw new FormatException("Nie podano liczby!");

            romeNumber = romeNumber.ToUpper();
            
            try
            {
                if (Regex.IsMatch(romeNumber, @"^[IVXLCDM]+$"))
                {
                    for (int i = romeNumber.Length - 1; i >= 0; i--)
                    {
                        int newNumber = numberValuePairs[romeNumber[i]];

                        if (newNumber < number)
                            arabicNumber = arabicNumber - newNumber;
                        else
                        {
                            arabicNumber = arabicNumber + newNumber;
                            number = newNumber;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Wpisano nieprawidłowe znaki!");
                }
            }
            catch (ArgumentException exc)
            {
                throw new ArgumentException("Wpisano nieprawidłowe znaki!", exc);
            }
            return arabicNumber;
        }
    }
}
