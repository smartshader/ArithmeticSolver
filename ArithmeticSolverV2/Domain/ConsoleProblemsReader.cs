using System;
using System.Collections.Generic;
using System.Linq;
using ArithmeticSolverV2.Common;

namespace ArithmeticSolverV2.Domain
{
    class ConsoleProblemsReader
    {
        public IEnumerable<ProblemStatement> ReadAll() =>
            RawNumbersSequence.Select(inputs => new ProblemStatement(inputs));

        private IEnumerable<IEnumerable<int>> RawNumbersSequence =>
            Console.In.IncomingLines().Select(line => line.ToNonNegativeInts());
    }
}