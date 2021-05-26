using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputFile = File.ReadAllLines("C:/AdventOfCode2020/Day4/Day4Input.txt");
            Console.WriteLine($"Solution for the first part: {DayFourPartOne(inputFile)}");
            Console.WriteLine($"Solution for the second part: {DayFourPartTwo(inputFile)}");
        }

        private static int DayFourPartOne(string[] inputFile)
        {
            int validPassports = 0;
            List<string> requiredFields = new List<string> { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };
            List<string> allPassports = new List<string>();
            string passport = String.Empty;

            foreach (var input in inputFile)
            {

                if (input == String.Empty)
                {
                    allPassports.Add(passport);
                    passport = string.Empty;
                    continue;
                }

                passport = passport + " " + input;

            }
            allPassports.Add(passport);

            foreach (string onePassport in allPassports)
            {
                int existingFields = 0;

                foreach (string field in requiredFields)
                {
                    if (onePassport.Contains(field))
                    {
                        existingFields++;
                    }
                }

                if (existingFields == 7)
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

        private static int DayFourPartTwo(string[] inputFile)
        {
            int validPassports = 0;
            List<string> validationRules = new List<string>() {
                                                     @"byr:(200[0-2]|19[2-9][0-9])",
                                                     @"iyr:(2020|201[0-9])",
                                                     @"eyr:(2030|202[0-9])",
                                                     @"hgt:((1[5-8][0-9]|19[0-3])cm)|hgt:(7[0-6]|59|6[0-9])in",
                                                     @"hcl:(#[0-9a-f]{6})",
                                                     @"ecl:(amb|blu|brn|gry|grn|hzl|oth)",
                                                     @"pid:(\d{9}\b)"
            };

            List<string> allPassports = new List<string>();
            string passport = String.Empty;

            foreach (var input in inputFile)
            {

                if (input == String.Empty)
                {
                    allPassports.Add(passport);
                    passport = string.Empty;
                    continue;
                }

                passport = passport + " " + input;

            }
            allPassports.Add(passport);

            foreach (string onePassport in allPassports)
            {
                if (validationRules.All(r => Regex.IsMatch(onePassport, r)))
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

    }
}