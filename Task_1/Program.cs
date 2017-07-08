using System;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string defaultInputFilePath = "..\\..\\InputFile.txt";
            const string defaultOutputFilePath = "..\\..\\OutputFile.txt";

            Console.Write("Enter the path to input file: ");
            var inputFilePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputFilePath))
            {
                inputFilePath = defaultInputFilePath;
                Console.WriteLine("Used default input file '{0}'\n", new FileInfo(inputFilePath).FullName);
            }

            Console.Write("Enter the path to output file: ");
            var outputFilePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(outputFilePath))
            {
                outputFilePath = defaultOutputFilePath;
                Console.WriteLine("Used default input file '{0}'\n", new FileInfo(outputFilePath).FullName);
            }

            Console.WriteLine();

            var sequenceSearcher = new SearcherOfSequence();

            try
            {
                sequenceSearcher.ReadFromFile(inputFilePath);
                sequenceSearcher.FindMaxSequenceOfOnes();
                sequenceSearcher.WriteToFile(outputFilePath);

                WriteToConsole(sequenceSearcher);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERROR: {0}\n", ex.Message);
            }

            Console.ReadKey();
        }

        public static void WriteToConsole(SearcherOfSequence sequenceSearcher)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Sequence: {0}", sequenceSearcher.InputData);
            Console.WriteLine("Longest sequence of ones: {0}", sequenceSearcher.OutputData);
            Console.WriteLine();

            for (var i = 0; i < sequenceSearcher.InputData.Length; i++)
            {
                if (i < sequenceSearcher.StartPosition || i >= sequenceSearcher.StartPosition + sequenceSearcher.MaxLength)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write(sequenceSearcher.InputData[i]);
            }

            Console.WriteLine("\n");
            Console.WriteLine("Max length:     {0}", sequenceSearcher.MaxLength);
            Console.WriteLine("Start position: {0}", sequenceSearcher.StartPosition);
            Console.WriteLine("------------------------------------");
        }
    }
}