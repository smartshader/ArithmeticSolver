using System.Collections.Generic;
using System.Linq;

namespace ArithmeticSolver
{
    internal class ValueAndUsedNumbersComparer : IEqualityComparer<ArithmeticExpression>
    {
        public bool Equals(ArithmeticExpression x, ArithmeticExpression y) =>
            x.Value == y.Value &&
            x.UsedNumbers.OrderBy(k => k).SequenceEqual(y.UsedNumbers.OrderBy(k => k));

        public int GetHashCode(ArithmeticExpression expr) =>
            expr.UsedNumbers.OrderBy(k => k)
                .Aggregate(expr.Value, (hash, number) => (hash << 1) ^ number);
    }
}