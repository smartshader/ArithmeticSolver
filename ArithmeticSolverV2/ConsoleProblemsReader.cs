using System;
using System.Collections.Generic;
using System.Linq;

namespace ArithmeticSolverV2
{
    class ConsoleProblemsReader
    {
        public IEnumerable<ProblemStatement> ReadAll() =>
            RawNumbersSequence.Select(inputs => new ProblemStatement(inputs));
        
        private IEnumerable<IEnumerable<int>> RawNumbersSequence =>
            Enumerable.Empty<IEnumerable<int>>();
    }
}