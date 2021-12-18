using System.Collections.Generic;

namespace ArithmeticSolverV2
{
    internal class ProblemStatement
    {
        public IEnumerable<int> InputNumbers { get; }
        
        public ProblemStatement(IEnumerable<int> inputs)
        {
            InputNumbers = inputs;
        }
    }
}