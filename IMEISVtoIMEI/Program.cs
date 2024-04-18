using System;

class Program
{
    //Main File
    static void Main()
    {
        //"35576205279323
        Console.WriteLine("Enter Value:");

        string imeisv = Console.ReadLine();
        string imei = ConvertIMEISVtoIMEI(imeisv);
        Console.WriteLine(imei);
    }
    //Convertion method
    static string ConvertIMEISVtoIMEI(string imeisv)
    {
        string imeiWithoutSVN = imeisv.Substring(0, imeisv.Length - 2);

 
        int checkDigit = CalculateLuhnCheckDigit(imeisv);
        string imei = imeisv + checkDigit.ToString();
        return imei;
    }
    //luhn Algorithm 
        static int CalculateLuhnCheckDigit(string input)
        {
            int sum = 0;
          bool doubleDigit = true;

            for (int i = 1; i < input.Length; i++)
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
           sum+= int.Parse(input[0].ToString());
        int checkDigit = (sum * 9) % 10;
        return checkDigit;
    }
}