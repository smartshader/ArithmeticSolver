using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArithmeticSolver
{
    internal class Program
    {
        private static void Main()
        {
            ProblemStatement problem = ReadProblem();
        }

        private static ProblemStatement ReadProblem()
        {
            Console.Write("Numbers to use (RETURN to exit): ");
            string line = Console.ReadLine() ?? string.Empty;
            string[] values = line.Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);

            List<int> input = values
                .Where(value => Regex.IsMatch(value, @"^\d+$"))
                .Select(int.Parse)
                .ToList();

            if (input.Count == 0)
                return null;
            
            Console.Write("           Enter desired result: ");
            string rawNumber = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(rawNumber, out int desiredResult))
                desiredResult = 0;
            
            return new ProblemStatement(input, desiredResult);
        }
    }
}