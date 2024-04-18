using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

class Program
{
    //Main File
    static void Main()
    {
        //Sample input 4535576205279323

        Console.WriteLine("Enter Value:");
        string input = Console.ReadLine();
        if (!IsNumeric(input))
        {
            Console.WriteLine("Please enter only numeric characters.");
        }
        else if (input.Length != 16)
        {
            Console.WriteLine("Please enter exactly 16 characters.");
        }
        else
        {
            string imei = ConvertIMEISVtoIMEI(input);
            Console.WriteLine(imei);
        }
    }
    static bool IsNumeric(string value)
    {
        return long.TryParse(value, out _);
    }
    //Convertion method
    static string ConvertIMEISVtoIMEI(string imeisv)
    {
        string imeiWithoutSVN = imeisv.Substring(0, imeisv.Length - 2);
        int checkDigit = CalculateLuhnCheckDigit(imeiWithoutSVN);
        string imei = imeiWithoutSVN + checkDigit.ToString();
        return imei;
    }
    //luhn Algorithm 
    static int CalculateLuhnCheckDigit(string input)
    {
        int sum = 0;
        bool doubleDigit = true;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(input[i].ToString());

            if (doubleDigit)
            {
                digit *= 2;

                if (digit > 9)
                {
                    digit -= 9;
                }
            }
            sum += digit;
            doubleDigit = !doubleDigit;
        }
        int checkDigit = (10 - (sum % 10)) % 10;
        return checkDigit;
    }
}