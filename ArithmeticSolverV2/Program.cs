using System;
using System.Collections.Generic;

namespace ArithmeticSolverV2
{
    internal static class Program
    {
        private static void Main()
        {
            ProblemStatements.WriteLinesTo(Console.Out);
        }

        private static IEnumerable<ProblemStatement> ProblemStatements =>
            new ConsoleProblemsReader().ReadAll();
    }
}