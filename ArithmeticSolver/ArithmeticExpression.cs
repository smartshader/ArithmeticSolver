using System;
using System.Collections.Generic;
using System.Linq;

namespace ArithmeticSolver
{
    internal class ArithmeticExpression : IEquatable<ArithmeticExpression>
    {
        public int Value { get; }

        public ArithmeticExpression RightChild { get; }

        public ArithmeticExpression LeftChild { get; }

        public char Operator { get; }
        
        public IEnumerable<int> UsedNumbers { get; }
        
        public ArithmeticExpression(int value)
        {
            Value = value;
            UsedNumbers = new[] {value};
            Operator = '\0';
        }

        private ArithmeticExpression(int value, char @operator, ArithmeticExpression leftChild, ArithmeticExpression rightChild)
        {
            Value = value;
            UsedNumbers = leftChild.UsedNumbers.Concat(rightChild.UsedNumbers);
            Operator = @operator;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public ArithmeticExpression CombineWith(ArithmeticExpression other, char @operator, int value) =>
            new ArithmeticExpression(value, @operator, this, other);

        public override string ToString() =>
            $"{PlainToString(this)} = {Value}";

        private string PlainToString(ArithmeticExpression expr) =>
            expr.Operator == '\0'
                ? $"{expr.Value}"
                : $"{expr.Parenthesize(expr.LeftChild)} {expr.Operator} {expr.Parenthesize(expr.RightChild)}";

        private string Parenthesize(ArithmeticExpression child) =>
            child.Operator == '\0' ? $"{child.Value}" : $"({PlainToString(child)})";

        private bool NullableEqual(ArithmeticExpression a, ArithmeticExpression b) =>
            a is null && b is null || a is not null && a.Equals(b);
        
        public override bool Equals(object other) => Equals(other as ArithmeticException);

        public bool Equals(ArithmeticExpression other) =>
            other is not null &&
            Value == other.Value &&
            Operator == other.Operator &&
            NullableEqual(LeftChild, other.LeftChild) &&
            NullableEqual(RightChild, other.RightChild);

        public override int GetHashCode() =>
            Operator.GetHashCode() ^
            Value << 1 ^
            (LeftChild?.GetHashCode() ?? 0) << 2 ^
            (RightChild?.GetHashCode() ?? 0) << 3;
    }
}