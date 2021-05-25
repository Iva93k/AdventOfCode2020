using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AdventDay2
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] inputFile = File.ReadAllLines("C:/AdventOfCode2020/Day2/DayTwoInput.txt");
			//string[] inputFile = new string[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };
			Console.WriteLine($"Solution for the first part: {DayTwoPartOne(inputFile)}");
			Console.WriteLine($"Solution for the second part: {DayTwoPartTwo(inputFile)}");
		}

		private static int DayTwoPartOne(string[] inputFile)
		{
			int numberOfCorrectPasswords = 0;

			foreach (var input in inputFile)
			{
				int numberOfAppearance = 0;

				int index = input.IndexOf(":");
				int indexOfDash = input.IndexOf("-");
				string firstInteger = input.Substring(0, indexOfDash);
				string secondInteger = input.Substring(indexOfDash + 1, 2);
				int minimum = int.Parse(firstInteger);
				int maximum = int.Parse(secondInteger);
				char keyCharacter = char.Parse(input.Substring(index - 1, 1));
				string password = input.Substring(index + 1);

				for (int i = 0; i < password.Length; i++)
				{
					if (password[i] == keyCharacter)
					{
						numberOfAppearance++;
					}
				}

				if (numberOfAppearance >= minimum && numberOfAppearance <= maximum)
				{
					numberOfCorrectPasswords++;
				}
			}

			return numberOfCorrectPasswords;
		}
		private static int DayTwoPartTwo(string[] inputFile)
		{
			int numberOfCorrectPasswords = 0;

			foreach (var input in inputFile)
			{
				int index = input.IndexOf(":");
				int indexOfDash = input.IndexOf("-");
				string firstInteger = input.Substring(0, indexOfDash);
				string secondInteger = input.Substring(indexOfDash + 1, 2);
				int minimum = int.Parse(firstInteger);
				int maximum = int.Parse(secondInteger);
				char keyCharacter = char.Parse(input.Substring(index - 1, 1));
				string password = input.Substring(index + 1);

				if ((password[minimum] == keyCharacter && password[maximum] != keyCharacter) || (password[minimum] != keyCharacter && password[maximum] == keyCharacter))
				{
					numberOfCorrectPasswords++;
				}
			}

			return numberOfCorrectPasswords;
		}

	}
}