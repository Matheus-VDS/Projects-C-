using System;

    public static class NumberExtensions
    {
        public static bool IsArmstrong(this int number)
        {
            if (number < 1) return false; 
            string numberString = number.ToString();
            int numDigits = numberString.Length;
            int sum = 0;

            foreach (char digitChar in numberString)
            {
                int digit = digitChar - '0'; 
                sum += (int)Math.Pow(digit, numDigits);
            }

            return sum == number;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Números de Armstrong de 1 a 10000:");

            for (int i = 1; i <= 10000; i++)
            {
                if (i.IsArmstrong())
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
