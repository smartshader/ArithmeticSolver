using System.Collections.Generic;
using System.Linq;

namespace ArithmeticSolverV2
{
    internal static class Program
    {
        private static void Main()
        {
            ProblemStatements.ToList().ForEach(_ => { });
        }

        private static IEnumerable<ProblemStatement> ProblemStatements =>
            new ConsoleProblemsReader().ReadAll();
    }
}