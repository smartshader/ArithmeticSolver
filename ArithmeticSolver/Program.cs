using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace ArithmeticSolver
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                ProblemStatement problem = ReadProblem();
                
                if (problem == null)
                    break;
                
                ArithmeticExpression solution = Solve(problem);
                
                string report = solution?.ToString() ?? "No solution found.";
                Console.WriteLine(report);
                Console.WriteLine();
            }
        }

        private static IEnumerable<int> ExceptWithDuplicates(IEnumerable<int> from, IEnumerable<int> remove) => from
            .Select(value => (value: value, count: 1))
            .Concat(remove.Select(value => (value: value, count: -1)))
            .GroupBy(tuple => tuple.value)
            .Select(group => (value: group.Key, count: group.Sum(tuple => tuple.count)))
            .Where(tuple => tuple.count > 0)
            .SelectMany(tuple => Enumerable.Repeat(tuple.value, tuple.count));

        private static bool IsSuperset(IEnumerable<int> sequence, IEnumerable<int> of) => sequence
            .Select(value => (value: value, count: 1))
            .Concat(of.Select(value => (value: value, count: -1)))
            .GroupBy(tuple => tuple.value)
            .All(group => group.Sum(tuple => tuple.count) >= 0);

        private static ArithmeticExpression Solve(ProblemStatement problem)
        {
            Queue<ArithmeticExpression> combining = new Queue<ArithmeticExpression>(
                problem.InputNumbers.Select(number => new ArithmeticExpression(number)));

            HashSet<ArithmeticExpression> known = new HashSet<ArithmeticExpression>(new ValueAndUsedNumbersComparer());

            while (combining.TryDequeue(out ArithmeticExpression current))
            {
                if (current.Value == problem.DesiredResult)
                    return current;

                IEnumerable<int> availableNumbers =
                    ExceptWithDuplicates(problem.InputNumbers, current.UsedNumbers);

                IEnumerable<ArithmeticExpression> combinableWith = known
                    .Where(expr =>
                        IsSuperset(availableNumbers, expr.UsedNumbers));

                foreach (ArithmeticExpression existing in combinableWith)
                {
                    combining.Enqueue(
                    current.CombineWith(existing, '+', current.Value + existing.Value));
                    
                    combining.Enqueue(
                    current.CombineWith(existing, '-', current.Value - existing.Value));
                    
                    combining.Enqueue(
                    current.CombineWith(current, '-', existing.Value - current.Value));
                    
                    combining.Enqueue(
                    current.CombineWith(existing, '*', current.Value * existing.Value));

                    if (existing.Value != 0 && current.Value % existing.Value == 0)
                    {
                        combining.Enqueue(
                        current.CombineWith(existing, '/', current.Value / existing.Value));
                    }

                    if (current.Value != 0 && existing.Value % current.Value == 0)
                    {
                        combining.Enqueue(
                        current.CombineWith(current, '/', existing.Value / current.Value));
                    }
                }
                
                known.Add(current);
            }

            return null;
        }

        private static ProblemStatement ReadProblem()
        {
            Console.Write("Numbers to use (RETURN to exit): ");
            string line = Console.ReadLine() ?? string.Empty;
            string[] values = line.Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);

            List<int> input = values
                .Where(value => Regex.IsMatch(value, @"^\d+$"))
                .Select(int.Parse)
                .ToList();

            if (input.Count == 0)
                return null;
            
            Console.Write("           Enter desired result: ");
            string rawNumber = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(rawNumber, out int desiredResult))
                desiredResult = 0;
            
            return new ProblemStatement(input, desiredResult);
        }
    }
}