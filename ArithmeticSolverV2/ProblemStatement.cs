using System.Collections.Generic;
using System.Linq;

namespace ArithmeticSolverV2
{
    internal class ProblemStatement
    {
        public IEnumerable<int> InputNumbers { get; }
        
        public ProblemStatement(IEnumerable<int> inputs)
        {
            InputNumbers = inputs;
        }

        public override string ToString() =>
            $"Problem statement: [{InputNumbersFormattedList}]";

        private string InputNumbersFormattedList =>
            string.Join(", ", InputNumbers.Select(number => $"{number}").ToArray());
    }
}