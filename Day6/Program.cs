using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputFile = File.ReadAllLines("C:/AdventOfCode2020/Day6/Day6Input.txt");
            Console.WriteLine($"Solution for the first part: {DaySixPartOne(inputFile)}");

        }

        private static int DaySixPartOne(string[] inputFile)
        {
            int sum = 0;
            List<string> allAnswers = new List<string>();
            string oneGroupAnswers = String.Empty;


            foreach (var input in inputFile)
            {

                if (input == String.Empty)
                {
                    allAnswers.Add(oneGroupAnswers);
                    oneGroupAnswers = string.Empty;
                    continue;
                }

                oneGroupAnswers = oneGroupAnswers + input;

            }
            allAnswers.Add(oneGroupAnswers);

            foreach (string answerFromoneGroup in allAnswers)
            {
                int count = answerFromoneGroup.Distinct().Count();
                sum += count;
            }

            return sum;
        }
    }
}
