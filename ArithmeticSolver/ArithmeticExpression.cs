namespace ArithmeticSolver
{
    internal class ArithmeticExpression
    {
        public int Value { get; }

        public ArithmeticExpression(int value)
        {
            Value = value;
        }

        public override string ToString() =>
            $"{Value}";
    }
}