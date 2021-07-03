using System.Collections.Generic;

namespace ArithmeticSolver
{
    internal class ProblemStatement
    {
        private readonly List<int> _input;
        private readonly int _desiredResult;

        public ProblemStatement(List<int> input, int desiredResult)
        {
            _input = input;
            _desiredResult = desiredResult;
        }
    }
}