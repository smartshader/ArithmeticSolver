using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArithmeticSolverV2.Common;

public static class EnumerableExtensions
{
    public static void WriteLinesTo<T>(this IEnumerable<T> sequence, TextWriter destination) =>
        sequence.Select(obj => $"{obj}").WriteLinesTo(destination);

    public static void WriteLinesTo(this IEnumerable<string> sequence, TextWriter destination)
    {
        foreach (string line in sequence)
            destination.WriteLine(line);
    }
}