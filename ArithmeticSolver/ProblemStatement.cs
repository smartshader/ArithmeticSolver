using System.Collections.Generic;

namespace ArithmeticSolver
{
    internal class ProblemStatement
    {
        public List<int> InputNumbers { get; }
        public int DesiredResult { get; }

        public ProblemStatement(List<int> input, int desiredResult)
        {
            InputNumbers = input;
            DesiredResult = desiredResult;
        }
    }
}