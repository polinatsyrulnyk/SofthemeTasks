using System;
using System.Collections.Generic;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = ReadNumber();
            var dividers = GetDividersOfNumber(number);

            Console.WriteLine();
            Console.WriteLine("Dividers of number {0}: ", number);

            for (var i = 0; i < dividers.Count; i++)
            {
                if (i == dividers.Count - 1)
                {
                    Console.WriteLine("{0}.", dividers[i]);
                }
                else
                {
                    Console.Write("{0}, ", dividers[i]);
                }
            }

            Console.ReadKey();
        }

        public static long ReadNumber()
        {
            long number;
            bool isCorrect;
            
            do
            {
                Console.Write("Enter a number: ");

                isCorrect = long.TryParse(Console.ReadLine(), out number);

                if (!isCorrect)
                {
                    Console.Write("Invalid number! Try again!\n\n");
                }
            } while (!isCorrect);

            return number;
        }

        public static List<long> GetDividersOfNumber(long number)
        {
            var dividers = new List<long>();

            if (number == 0)
            {
                return dividers;
            }

            dividers.Add(1);
            dividers.Add(-1);

            if (number < 0)
            {
                number *= -1;
            }

            var maxDivider = (long)Math.Sqrt(number);

            for (var i = 2; i <= maxDivider; i++)
            {
                if (number % i == 0)
                {
                    dividers.Add(i);
                    dividers.Add(-i);
                }
            }

            dividers.Add(number);
            dividers.Add(-number);
            
            return dividers;
        }
    }
}
