using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ArithmeticSolverV2.Common;

namespace ArithmeticSolverV2.Domain
{
    class ConsoleProblemsReader
    {
        public IEnumerable<ProblemStatement> ReadAll() =>
            RawNumbersSequence.Select(inputs => new ProblemStatement(inputs));

        private IEnumerable<IEnumerable<int>> RawNumbersSequence =>
            Console.In.IncomingLines()
                .Where(line => Regex.IsMatch(line, @"^[ \t\d]+$"))
                .Where(line => Regex.Matches(line, @"\d+")
                    .All(match => int.TryParse(match.Value, out _)))
                .Select(line => line.ToNonNegativeInts())
                .Where(numbers => numbers.Any());
    }
}