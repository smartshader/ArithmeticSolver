using System;
using System.Collections.Generic;
using ArithmeticSolverV2.Common;
using ArithmeticSolverV2.Domain;

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