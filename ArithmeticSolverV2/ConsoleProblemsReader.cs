using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArithmeticSolverV2
{
    class ConsoleProblemsReader
    {
        public IEnumerable<ProblemStatement> ReadAll() =>
            RawNumbersSequence.Select(inputs => new ProblemStatement(inputs));

        private IEnumerable<IEnumerable<int>> RawNumbersSequence =>
            Console.In.IncomingLines().Select(ToUnsignedInts);

        private IEnumerable<int> ToUnsignedInts(string line) =>
            Regex.Matches(line, @"\d+")
                .Select(match => match.Value)
                .Select(int.Parse);
    }
}