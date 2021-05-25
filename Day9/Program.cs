using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputFile = File.ReadAllLines("C:/AdventOfCode2020/Day9/DayNineInput.txt");
            //string[] inputFile = File.ReadAllLines("C:/AdventOfCode2020/Day9/Day9ShortInput.txt");
            long[] inputList = Array.ConvertAll(inputFile, s => long.Parse(s));
            long wantedNumber = DayNinePartOne(inputList);

            Console.WriteLine($"Solution for the first part: {wantedNumber}");
            Console.WriteLine($"Solution for the second part: {DayNinePartTwo(inputList, wantedNumber)}");

        }

        private static long DayNinePartOne(long[] inputList)
        {
            //int preamble = 5;
            int preamble = 25;

            for (int i = preamble; i < inputList.Length; i++)
            {
                long currentNumber = inputList[i]; //26
                int startFromIndex = i - preamble; //1
                List<long> validNumbers = new List<long>();

                for (int j = startFromIndex; j < i; j++)
                {
                    for (int k = startFromIndex; k < i; k++)
                    {
                        if (inputList[j] != inputList[k])
                        {
                            if (inputList[j] + inputList[k] == currentNumber)
                            {
                                validNumbers.Add(currentNumber);
                            }
                        }
                    }
                }

                if (!validNumbers.Contains(currentNumber))
                {
                    return currentNumber;
                }
            }

            return 0;
        }

        private static long DayNinePartTwo(long[] inputList, long wantedNumber)
        {
            for (int i = 0; i < inputList.Length; i++)
            {
                for (int j = i + 2; j < inputList.Length; j++)
                {
                    long[] sectionOfNumbers = new long[j - i + 1];
                    Array.Copy(inputList, i, sectionOfNumbers, 0, j - i + 1);

                    long sum = sectionOfNumbers.Sum();
                    if (sum == wantedNumber)
                    {
                        long weakness = sectionOfNumbers.Min() + sectionOfNumbers.Max();
                        return weakness;
                    }
                }
            }
            return 0;
        }
    }
}