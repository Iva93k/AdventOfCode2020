using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputFile = File.ReadAllLines("C:/AdventOfCode2020/Day10/Day10Input.txt");
            List<int> inputs = (Array.ConvertAll(inputFile, s => int.Parse(s))).ToList();

            Console.WriteLine($"Solution for the first part: {DayTenPartOne(inputs)}");
        }

        private static int DayTenPartOne(List<int> inputs)
        {
            int oneJoltDifferences = 0;
            int threeJoltsDifferences = 0;

            inputs.Insert(0, 0);
            int builtInAdapterJoltage = inputs.Max() + 3;
            inputs.Add(builtInAdapterJoltage);
            inputs.Sort();

            for (int i = 0; i < inputs.Count - 1; i++)
            {
                int firstComparator = inputs[i];
                int secondComparator = inputs[i + 1];

                if (secondComparator - firstComparator == 1)
                {
                    oneJoltDifferences++;
                }
                else if (secondComparator - firstComparator == 3)
                {
                    threeJoltsDifferences++;
                }
            }
            int result = oneJoltDifferences * threeJoltsDifferences;

            return result;

        }
    }
}
